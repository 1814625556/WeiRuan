using System;
using System.Collections.Generic;
using System.Linq;

namespace SuanFa
{
    class Program
    {
        public static int Y = A.X + 1;
        static Program()
        { 
        }
        static void Main(string[] args)
        {
            ListNode node7 = new ListNode(7, null);
            ListNode node6 = new ListNode(6, node7);
            ListNode node5 = new ListNode(5, node6);
            ListNode node4 = new ListNode(4, node5);
            ListNode node3 = new ListNode(3, node4);
            ListNode node2 = new ListNode(2, node3);
            ListNode node1 = new ListNode(1, node2);
            Practice2.ReverseKGroup(node1, 3);
            
            Console.ReadKey();
        }
    }

    interface IInvoiceRepository
    {
        decimal? GetTotal(int invoiceId);
        decimal GetTotalOfUnpaid();

        IReadOnlyDictionary<string, long> GetItemsReport(DateTime? from, DateTime? to);
    }
    public class InvoiceRepository : IInvoiceRepository
    {
        private IList<Invoice> myInvoices;
        public InvoiceRepository(IQueryable<Invoice> invoices)
        {
            // Console.WriteLine("Sample debug output");
            if (invoices == null)
                throw new ArgumentNullException("invoices is null");
            myInvoices = invoices.ToList();
        }

        /// <summary>
        /// Should return a total value of an invoice with a given id. If an invoice does not exist null should be returned.
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public decimal? GetTotal(int invoiceId)
        {
            var en = myInvoices.FirstOrDefault(x => x.Id == invoiceId);
            if (en == null) return null;
            return en.InvoiceItems.Sum(x => x.Price * x.Count);
        }

        /// <summary>
        /// Should return a total value of all unpaid invoices.
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalOfUnpaid()
        {
            var unpaidInvoices = myInvoices.Where(x => x.AcceptanceDate > DateTime.Now);
            decimal? sum = 0;
            foreach (var invoice in unpaidInvoices)
            {
                sum += GetTotal(invoice.Id);
            }
            return Convert.ToDecimal(sum);
        }

        /// <summary>
        /// Should return a dictionary where the name of an invoice item is a key and the number of bought items is a value.
        /// The number of bought items should be summed within a given period of time (from, to). Both the from date and the end date can be null.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public IReadOnlyDictionary<string, long> GetItemsReport(DateTime? from, DateTime? to)
        {
            var dic = new Dictionary<string, long>();
            IEnumerable<Invoice> fitInvoices = myInvoices;
            if (from != null)
                fitInvoices = myInvoices.Where(x => x.AcceptanceDate > from);
            if(to != null)
                fitInvoices = myInvoices.Where(x => x.CreationDate < to);

            foreach (var invoice in fitInvoices)
            {
                dic.Add(invoice.Number, invoice.InvoiceItems.Sum(x=>x.Count));
            }

            return dic;
        }
    }
}

public class Invoice
{
    // A unique numerical identifier of an invoice (mandatory)
    public int Id { get; set; }
    // A short description of an invoice (optional).
    public string Description { get; set; }
    // A number of an invoice e.g. 134/10/2018 (mandatory).
    public string Number { get; set; }
    // An issuer of an invoice e.g. Metz-Anderson, 600  Hickman Street,Illinois (mandatory).
    public string Seller { get; set; }
    // A buyer of a service or a product e.g. John Smith, 4285  Deercove Drive, Dallas (mandatory).
    public string Buyer { get; set; }
    // A date when an invoice was issued (mandatory).
    public DateTime CreationDate { get; set; }
    // A date when an invoice was paid (optional).
    public DateTime? AcceptanceDate { get; set; }
    // A collection of invoice items for a given invoice (can be empty but is never null).
    public IList<InvoiceItem> InvoiceItems { get; }

    public Invoice()
    {
        InvoiceItems = new List<InvoiceItem>();
    }
}
public class InvoiceItem
{
    // A name of an item e.g. eggs.
    public string Name { get; set; }
    // A number of bought items e.g. 10.
    public int Count { get; set; }
    // A price of an item e.g. 20.5.
    public decimal Price { get; set; }
}

class A
{
    public static int X;
    static A()
    {

    }
}
