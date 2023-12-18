using ParseData;

FetchDB fetchDB = new FetchDB();
var books = fetchDB.ParseBooks("./Books_table.tsv");

