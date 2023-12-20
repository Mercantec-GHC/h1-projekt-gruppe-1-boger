using Domain_Models.Webshop.Medias;


var bookDbContext = new BookDbContext();

Console.WriteLine(bookDbContext.Get(101));
Console.WriteLine(bookDbContext.Get(101).Author);


