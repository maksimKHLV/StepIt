//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using kargo.Message;

//namespace kargo.Model;

//public class UserInfocs:ISendable,ICloneable
//{
//    public string? UserName { get; set; }
//    public string? Password { get; set; }
//    public string? Email { get; set; }
//    public string? FIN { get; set; }
//    public string? Address { get; set; }
//    public List<Goods>? HistoryGoods { get; set; }


//    public ObservableCollection<Declarationcs>? UserDeclarations { get; set; } = new();

//    public override string ToString()
//    {
//        return $"Username:{UserName}" +
//               $"Password:{Password}" +
//               $"Adress:{Address}" +
//               $"Fin:{FIN}";
//    }

//    public object Clone()
//    {
//        return new UserInfocs()
//        {
//            Address = Address,
//            Password = Password,
//            UserName = UserName,
//            FIN = FIN,
//            UserDeclarations = UserDeclarations,
//        };  
//    }

//}