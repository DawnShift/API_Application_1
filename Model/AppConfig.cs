namespace API_Application_1.Model
{
    public class AppConfig
    {
        public MongoSettings MongoSettings { get; set; }
        public string ServiceBus { get; set; }
    }

    public class MongoSettings
    {
        public string Connection { get; set; }
        public string DBName { get; set; }
    }
}
