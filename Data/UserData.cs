using BEDuo.Models;

namespace BEDuo.Data
{
    public class UserData
    {
        public static List<User> Users = new List<User>
        {
            new User()
            { 
                Id= 1,
                Username="kikilearn",
                University="Western Governor's University",
                Uid="RjGMb2h53VelT6Mis05ekXrRxvG2",
                Bio="Night Owl looking to learn!"
            },
            new User()
            {
                Id= 2,
                Username="zel",
                Uid="EBdW2g5N9xddUcK048GpXjvaUrq1",
                Bio="THS <3, cat mom first, AP student second."
            },
        };
    }
}
