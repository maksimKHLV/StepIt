using kargo.Message;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace kargo.Model;

public class User : ICloneable, ISendable
{
    public string?  UserName { get; set; } 
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? FIN { get; set; }
    public string? Address { get; set; }
    public ObservableCollection<Declarationcs>? HistoryGoods { get; set; } = new();

    public object Clone()           
    {
        return new User()
        {
            Address = Address,

            Password = Password,
            UserName = UserName,
            FIN = FIN,
            HistoryGoods = HistoryGoods,
        };
    }
}