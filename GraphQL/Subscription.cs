public class Subscription
{
    [Subscribe] 
    public Book OnBookAdded([EventMessage] Book book) => book;
}