/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Saft
{
	[XmlRoot(ElementName = "CompanyAddress", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
	public class CompanyAddress
	{
		[XmlElement(ElementName = "StreetName", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string StreetName { get; set; }
		[XmlElement(ElementName = "AddressDetail", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string AddressDetail { get; set; }
		[XmlElement(ElementName = "City", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string City { get; set; }
		[XmlElement(ElementName = "PostalCode", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string PostalCode { get; set; }
		[XmlElement(ElementName = "Region", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string Region { get; set; }
		[XmlElement(ElementName = "Country", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string Country { get; set; }
	}

	[XmlRoot(ElementName = "Header", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
	public class Header
	{
		[XmlElement(ElementName = "AuditFileVersion", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string AuditFileVersion { get; set; }
		[XmlElement(ElementName = "CompanyID", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string CompanyID { get; set; }
		[XmlElement(ElementName = "TaxRegistrationNumber", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string TaxRegistrationNumber { get; set; }
		[XmlElement(ElementName = "TaxAccountingBasis", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string TaxAccountingBasis { get; set; }
		[XmlElement(ElementName = "CompanyName", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string CompanyName { get; set; }
		[XmlElement(ElementName = "CompanyAddress", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public CompanyAddress CompanyAddress { get; set; }
		[XmlElement(ElementName = "FiscalYear", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string FiscalYear { get; set; }
		[XmlElement(ElementName = "StartDate", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string StartDate { get; set; }
		[XmlElement(ElementName = "EndDate", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string EndDate { get; set; }
		[XmlElement(ElementName = "CurrencyCode", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string CurrencyCode { get; set; }
		[XmlElement(ElementName = "DateCreated", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string DateCreated { get; set; }
		[XmlElement(ElementName = "TaxEntity", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string TaxEntity { get; set; }
		[XmlElement(ElementName = "ProductCompanyTaxID", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string ProductCompanyTaxID { get; set; }
		[XmlElement(ElementName = "SoftwareCertificateNumber", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string SoftwareCertificateNumber { get; set; }
		[XmlElement(ElementName = "ProductID", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string ProductID { get; set; }
		[XmlElement(ElementName = "ProductVersion", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string ProductVersion { get; set; }
	}

	[XmlRoot(ElementName = "BillingAddress", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
	public class BillingAddress
	{
		[XmlElement(ElementName = "AddressDetail", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string AddressDetail { get; set; }
		[XmlElement(ElementName = "City", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string City { get; set; }
		[XmlElement(ElementName = "PostalCode", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string PostalCode { get; set; }
		[XmlElement(ElementName = "Country", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string Country { get; set; }
	}

	[XmlRoot(ElementName = "Customer", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
	public class Customer
	{
		[XmlElement(ElementName = "CustomerID", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string CustomerID { get; set; }
		[XmlElement(ElementName = "AccountID", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string AccountID { get; set; }
		[XmlElement(ElementName = "CustomerTaxID", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string CustomerTaxID { get; set; }
		[XmlElement(ElementName = "CompanyName", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string CompanyName { get; set; }
		[XmlElement(ElementName = "BillingAddress", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public BillingAddress BillingAddress { get; set; }
		[XmlElement(ElementName = "SelfBillingIndicator", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string SelfBillingIndicator { get; set; }
		[XmlElement(ElementName = "Telephone", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string Telephone { get; set; }
		[XmlElement(ElementName = "Fax", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string Fax { get; set; }
		[XmlElement(ElementName = "Website", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string Website { get; set; }
	}

	[XmlRoot(ElementName = "TaxTableEntry", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
	public class TaxTableEntry
	{
		[XmlElement(ElementName = "TaxType", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string TaxType { get; set; }
		[XmlElement(ElementName = "TaxCountryRegion", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string TaxCountryRegion { get; set; }
		[XmlElement(ElementName = "TaxCode", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string TaxCode { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string Description { get; set; }
		[XmlElement(ElementName = "TaxPercentage", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string TaxPercentage { get; set; }
	}

	[XmlRoot(ElementName = "TaxTable", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
	public class TaxTable
	{
		[XmlElement(ElementName = "TaxTableEntry", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public TaxTableEntry TaxTableEntry { get; set; }
	}

	[XmlRoot(ElementName = "Product", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
	public class Product
	{
		[XmlElement(ElementName = "ProductType", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string ProductType { get; set; }
		[XmlElement(ElementName = "ProductCode", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string ProductCode { get; set; }
		[XmlElement(ElementName = "ProductGroup", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string ProductGroup { get; set; }
		[XmlElement(ElementName = "ProductDescription", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string ProductDescription { get; set; }
		[XmlElement(ElementName = "ProductNumberCode", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string ProductNumberCode { get; set; }
	}

	[XmlRoot(ElementName = "MasterFiles", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
	public class MasterFiles
	{
		[XmlElement(ElementName = "Customer", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public List<Customer> Customer { get; set; }
		[XmlElement(ElementName = "TaxTable", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public List<TaxTable> TaxTable { get; set; }
		[XmlElement(ElementName = "Product", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public List<Product> Product { get; set; }
	}

	[XmlRoot(ElementName = "Tax", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
	public class Tax
	{
		[XmlElement(ElementName = "TaxType", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string TaxType { get; set; }
		[XmlElement(ElementName = "TaxCountryRegion", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string TaxCountryRegion { get; set; }
		[XmlElement(ElementName = "TaxCode", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string TaxCode { get; set; }
		[XmlElement(ElementName = "TaxPercentage", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string TaxPercentage { get; set; }
	}

	[XmlRoot(ElementName = "Line", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
	public class Line
	{
		[XmlElement(ElementName = "LineNumber", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string LineNumber { get; set; }
		[XmlElement(ElementName = "ProductCode", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string ProductCode { get; set; }
		[XmlElement(ElementName = "ProductDescription", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string ProductDescription { get; set; }
		[XmlElement(ElementName = "Quantity", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string Quantity { get; set; }
		[XmlElement(ElementName = "UnitOfMeasure", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string UnitOfMeasure { get; set; }
		[XmlElement(ElementName = "UnitPrice", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string UnitPrice { get; set; }
		[XmlElement(ElementName = "TaxPointDate", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string TaxPointDate { get; set; }
		[XmlElement(ElementName = "Description", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string Description { get; set; }
		[XmlElement(ElementName = "CreditAmount", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string CreditAmount { get; set; }
		[XmlElement(ElementName = "Tax", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public Tax Tax { get; set; }
		[XmlElement(ElementName = "SettlementAmount", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string SettlementAmount { get; set; }
		[XmlElement(ElementName = "OrderReferences", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public OrderReferences OrderReferences { get; set; }
		[XmlElement(ElementName = "TaxExemptionReason", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string TaxExemptionReason { get; set; }
	}

	[XmlRoot(ElementName = "DocumentTotals", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
	public class DocumentTotals
	{
		[XmlElement(ElementName = "TaxPayable", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string TaxPayable { get; set; }
		[XmlElement(ElementName = "NetTotal", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string NetTotal { get; set; }
		[XmlElement(ElementName = "GrossTotal", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string GrossTotal { get; set; }
	}

	[XmlRoot(ElementName = "Invoice", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
	public class Invoice
	{
		[XmlElement(ElementName = "InvoiceNo", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string InvoiceNo { get; set; }
		[XmlElement(ElementName = "InvoiceStatus", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string InvoiceStatus { get; set; }
		[XmlElement(ElementName = "Hash", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string Hash { get; set; }
		[XmlElement(ElementName = "HashControl", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string HashControl { get; set; }
		[XmlElement(ElementName = "Period", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string Period { get; set; }
		[XmlElement(ElementName = "InvoiceDate", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string InvoiceDate { get; set; }
		[XmlElement(ElementName = "InvoiceType", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string InvoiceType { get; set; }
		[XmlElement(ElementName = "SelfBillingIndicator", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string SelfBillingIndicator { get; set; }
		[XmlElement(ElementName = "SystemEntryDate", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string SystemEntryDate { get; set; }
		[XmlElement(ElementName = "CustomerID", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string CustomerID { get; set; }
		[XmlElement(ElementName = "Line", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public List<Line> Line { get; set; }
		[XmlElement(ElementName = "DocumentTotals", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public DocumentTotals DocumentTotals { get; set; }
	}

	[XmlRoot(ElementName = "OrderReferences", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
	public class OrderReferences
	{
		[XmlElement(ElementName = "OriginatingON", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string OriginatingON { get; set; }
		[XmlElement(ElementName = "OrderDate", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string OrderDate { get; set; }
	}

	[XmlRoot(ElementName = "SalesInvoices", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
	public class SalesInvoices
	{
		[XmlElement(ElementName = "NumberOfEntries", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string NumberOfEntries { get; set; }
		[XmlElement(ElementName = "TotalDebit", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string TotalDebit { get; set; }
		[XmlElement(ElementName = "TotalCredit", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public string TotalCredit { get; set; }
		[XmlElement(ElementName = "Invoice", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public List<Invoice> Invoice { get; set; }
	}

	[XmlRoot(ElementName = "SourceDocuments", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
	public class SourceDocuments
	{
		[XmlElement(ElementName = "SalesInvoices", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public SalesInvoices SalesInvoices { get; set; }
	}

	[XmlRoot(ElementName = "AuditFile", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
	public class AuditFile
	{
		[XmlElement(ElementName = "Header", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public Header Header { get; set; }
		[XmlElement(ElementName = "MasterFiles", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public MasterFiles MasterFiles { get; set; }
		[XmlElement(ElementName = "SourceDocuments", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.01_01")]
		public SourceDocuments SourceDocuments { get; set; }
		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; }
		[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Xsi { get; set; }
		[XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public string SchemaLocation { get; set; }
		[XmlAttribute(AttributeName = "doc", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Doc { get; set; }
	}

}
