namespace LinkedListSample
{
    ////priority queue . every priority got a queue . if number exist add to queue else create new queue
    class Program
    {
        static void Main()
        {
            var pdm = new PriorityDocumentManager();
            pdm.AddDocument(new Document("one", "Sample", 8));
            pdm.AddDocument(new Document("two", "Sample", 3));
            pdm.AddDocument(new Document("three", "Sample", 4));
            pdm.AddDocument(new Document("four", "Sample", 8));
            pdm.AddDocument(new Document("five", "Sample", 1));
            pdm.AddDocument(new Document("six", "Sample", 9));
            pdm.AddDocument(new Document("seven", "Sample", 1));
            pdm.AddDocument(new Document("eight", "Sample", 1));

            pdm.DisplayAllNodes();


             var pdm2 = new PriorityDocumentManager2();
            pdm2.AddDocument(new Document("one", "Sample", 8));
            pdm2.AddDocument(new Document("two", "Sample", 3));
            pdm2.AddDocument(new Document("three", "Sample", 4));
            pdm2.AddDocument(new Document("four", "Sample", 8));
            pdm2.AddDocument(new Document("five", "Sample", 1));
            pdm2.AddDocument(new Document("six", "Sample", 9));
            pdm2.AddDocument(new Document("seven", "Sample", 1));
            pdm2.AddDocument(new Document("eight", "Sample", 1));

            pdm2.DisplayAllNodes();
        }
    }
}
