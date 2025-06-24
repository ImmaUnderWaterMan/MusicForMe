namespace case_4
{
    public class Audio
    {
        public int ID { get; }
        public AudioMetadata Metadata { get; }
        public AudioProperties Properties { get; }

        public Audio(int id, AudioMetadata metadata, AudioProperties properties)
        {
            ID = id;
            Metadata = metadata;
            Properties = properties;
        }
    }
}