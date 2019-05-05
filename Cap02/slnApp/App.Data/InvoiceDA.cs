using App.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Transactions;

namespace App.Data
{
    public class InvoiceDA : BaseConnection
    {
        public int InsertTXLocal(Invoice invoice)
        {
            var result = 0;
            using (IDbConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                var tx = cn.BeginTransaction();
                try
                {
                    var invoiceId = cn.ExecuteScalar<int>("usp_InsertInvoice",
                           new
                           {
                               CustomerId = invoice.CustomerId,
                               InvoiceDate = invoice.InvoiceDate,
                               BillingAddress = invoice.BillingAddress,
                               BillingCity = invoice.BillingCity,
                               BillingState = invoice.BillingState,
                               BillingCountry = invoice.BillingCountry,
                               BillingPostalCode = invoice.BillingPostalCode,
                               Total = invoice.Total
                           }, commandType: CommandType.StoredProcedure,
                           transaction: tx);
                    foreach (var item in invoice.InvoiceLines)
                    {
                        cn.Execute("usp_InsertInoviceLine",
                            new
                            {
                                InvoiceId = invoiceId,
                                item.TrackId,
                                item.UnitPrice,
                                item.Quantity,
                            }, commandType: CommandType.StoredProcedure,
                            transaction: tx);
                    }
                    //throw new Exception("Error");
                    tx.Commit();
                    result = invoiceId;
                }
                catch (Exception)
                {
                    result = 0;
                    tx.Rollback();
                }
            }
            return result;
        }

        public int InsertTXDist(Invoice invoice)
        {
            var result = 0;
            using (var tx = new TransactionScope())
            {
                try
                {
                    using (IDbConnection cn = new SqlConnection(ConnectionString))
                    {
                        var invoiceId = cn.ExecuteScalar<int>("usp_InsertInvoice",
                               new
                               {
                                   invoice.CustomerId,
                                   invoice.InvoiceDate,
                                   invoice.BillingAddress,
                                   invoice.BillingCity,
                                   invoice.BillingState,
                                   invoice.BillingCountry,
                                   invoice.BillingPostalCode,
                                   invoice.Total
                               }, commandType: CommandType.StoredProcedure);
                        foreach (var item in invoice.InvoiceLines)
                        {
                            cn.Execute("usp_InsertInoviceLine",
                                new
                                {
                                    InvoiceId = invoiceId,
                                    item.TrackId,
                                    item.UnitPrice,
                                    item.Quantity,
                                }, commandType: CommandType.StoredProcedure);
                        }
                        result = invoiceId;
                    }
                    tx.Complete();
                }
                catch (Exception)
                {
                    result = 0;
                }
            }
            return result;
        }
    }
}
