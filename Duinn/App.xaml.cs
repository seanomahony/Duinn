using Xamarin.Forms;

namespace Duinn
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            //EventPersistence.ClearEvents();
            //EventPersistence.SaveFromString("[{\"ID\":\"0e3b5561-ad41-4113-9d93-7701e62f9efc\",\"Title\":\"St. Amy's day\",\"StartDate\":\"2023-09-14T00:00:00\",\"EndDate\":\"2023-09-14T00:00:00\",\"Description\":null,\"User\":2},{\"ID\":\"04b1493b-5056-46a6-908e-d69be91d7b09\",\"Title\":\"Wedding \",\"StartDate\":\"2023-08-20T00:00:00\",\"EndDate\":\"2023-08-20T00:00:00\",\"Description\":\"Dan's wedding Doolin \",\"User\":2},{\"ID\":\"85529555-c90f-4ead-a402-0a930cb753a7\",\"Title\":\"Chris Kent \",\"StartDate\":\"2023-10-14T00:00:00\",\"EndDate\":\"2023-10-14T00:00:00\",\"Description\":null,\"User\":2},{\"ID\":\"2d64ee42-e391-4436-a532-77cbca805140\",\"Title\":\"Hamilton \",\"StartDate\":\"2024-10-16T00:00:00\",\"EndDate\":\"2024-10-16T00:00:00\",\"Description\":\"Dublin \",\"User\":0},{\"ID\":\"b2eb13ff-5ddb-45f6-8ce6-62aa581bd90d\",\"Title\":\"Tadgh Hickey \",\"StartDate\":\"2023-09-28T00:00:00\",\"EndDate\":\"2023-09-28T00:00:00\",\"Description\":\"8pm Opera House \",\"User\":2},{\"ID\":\"d8670a22-d1a7-4143-b452-8ba02345da2d\",\"Title\":\"Ireland u21\",\"StartDate\":\"2023-09-08T00:00:00\",\"EndDate\":\"2023-09-08T00:00:00\",\"Description\":\"Game in Turner's Cross \",\"User\":1},{\"ID\":\"7cde69d8-17ac-42e1-9aff-8c2b3c218bcc\",\"Title\":\"Ireland u21 \",\"StartDate\":\"2023-09-12T00:00:00\",\"EndDate\":\"2023-09-12T00:00:00\",\"Description\":\"Turner's Cross \",\"User\":1},{\"ID\":\"c2d736cf-8544-45ba-9124-e18946965883\",\"Title\":\"Gavin's birthday \",\"StartDate\":\"2023-10-21T00:00:00\",\"EndDate\":\"2023-10-21T00:00:00\",\"Description\":\"Imperial hotel \",\"User\":2},{\"ID\":\"2c251017-c607-4206-9d86-c196dba45731\",\"Title\":\"EN Doc\",\"StartDate\":\"2023-09-01T00:00:00\",\"EndDate\":\"2023-09-01T00:00:00\",\"Description\":\"Online - need to check time \",\"User\":0},{\"ID\":\"19a9c0cf-4af1-4dd4-b591-701290fcb6da\",\"Title\":\"test\",\"StartDate\":\"2023-08-16T17:14:35.370782+01:00\",\"EndDate\":\"2023-08-16T17:14:35.370797+01:00\",\"Description\":\"abc\",\"User\":0}]");
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
