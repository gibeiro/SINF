create table customer(
	customerid text,
	accountid integer,
	customertaxid integer,
	companyname text,
	address text,
	city text,
	postalcode integer,
	country text,
	telephone integer,
	fax integer,
	website text,

);
create table product();
create table invoice();
create table line();

<Customer>
			<CustomerID>ALCAD</CustomerID>
			<AccountID>21123004</AccountID>
			<CustomerTaxID>989922456</CustomerTaxID>
			<CompanyName>Soluciones Cad de Madrid, SA</CompanyName>
			<BillingAddress>
				<AddressDetail>PASSEO DE PORTUGAL, 464646</AddressDetail>
				<City>VILANUEVA DE ARRIBA</City>
				<PostalCode>61001</PostalCode>
				<Country>ES</Country>
			</BillingAddress>
			<Telephone>00.034.1.474747447</Telephone>
			<Fax>00.034.1.4374747474</Fax>
			<Website>http://alcad.es</Website>
			<SelfBillingIndicator>0</SelfBillingIndicator>
		</Customer>