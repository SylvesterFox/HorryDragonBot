
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DragonData.Module;

public class BlocklistModule
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public ulong userID { get; set; }
    public UserModule User { get; set; }
    public string blockTag { get; set; }

}
