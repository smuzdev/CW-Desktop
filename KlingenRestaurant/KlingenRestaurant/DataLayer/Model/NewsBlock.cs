namespace KlingenRestaurant
{
    public class NewsBlock
    {
        public int NewsBlockId { get; set; }
        public string NewsBlockTitle { get; private set; }
        public string NewsBlockDescription { get; private set; }
        public byte[] NewsBlockImage { get; private set; }

        public NewsBlock() { }

        public NewsBlock(string newsBlockTitle, string newsBlockDescription, byte[] newsBlockImage)
        {
            NewsBlockTitle = newsBlockTitle;
            NewsBlockDescription = newsBlockDescription;
            NewsBlockImage = newsBlockImage;
        }
    }
}
