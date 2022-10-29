using System.Linq.Expressions;

namespace SocialMedia.Models;


public class QueryOptions<T> {


    public Expression<Func<T, Object>> OrderBy { get; set; }
    public string OrderByDirection { get; set; } = "asc";
    public int PageSize { get; set; }

    private string[] includes;

     public string Include {
        set => includes = value.Replace(" ", "").Split(",");
    }

     public string[] GetIncludes() => includes ?? new string[0];

    public WhereClauses<T> WhereClauses { get; set; }

    public Expression<Func<T, bool>> Where {
        set {
            if(WhereClauses == null) {
                WhereClauses = new WhereClauses<T>();
            }

            WhereClauses.Add(value);
        }
    }


    public bool HasWhere => WhereClauses != null;

    public bool HasOrderBy => OrderBy != null;

    public bool HasPaging => PageSize > 0;
}


public class WhereClauses<T> : List<Expression<Func<T, bool>>> {}