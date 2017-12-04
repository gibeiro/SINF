create table customer(
	id text primary key not null,
	accountid integer,
	customertaxid integer,
	companyname text,
	address text,
	city text,
	postalcode integer,
	country text,
	telephone integer,
	fax integer,
	website text
);

create table product(
	type text,
	code text primary key not null,
	productgroup text,
	description text,
	numbercode text
);
create table invoice(
	number text primary key not null,
	status text,
	hash text,
	hashcontrol integer,
	period integer,
	date text,
	type text,
	selfbillingindicator integer,
	entrydate text,
	customerid text not null,
	taxpayable real,
	nettotal real,
	grosstotal real,
	foreign key (customerid) references customer(id)
);

create table line(
	invoicenumber text not null,
	number integer not null,
	productcode text not null,
	quantity integer,
	unitofmeasure text,
	unitprice real,
	taxpointdate text,
	description text,
	creditamount real,
	settlement real,
	taxtype text,
	taxregion text,
	taxcode text,
	taxpercentage real,
	foreign key (productcode) references product(code),
	foreign key (invoicenumber) references invoice(number),
	primary key(invoicenumber,number)
);