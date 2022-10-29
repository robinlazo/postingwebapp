namespace SocialMedia.Models;

public class SortDictionary : Dictionary<string, string> {

    
    public string SortDirection {
        get => Get(nameof(IndexDTO.SortDirection));
        set => this[nameof(IndexDTO.SortDirection)] = value;
    } 

    public string CategoryFilter {
        get => Get(nameof(IndexDTO.Category));
        set => this[nameof(IndexDTO.Category)] = value;
    }


    public void SetFilterAndDirection(string category, SortDictionary current) {
        this[nameof(IndexDTO.Category)] = category;

        if(current.CategoryFilter.EqualsNoCase(category) && current.SortDirection == "asc") {
            this[nameof(IndexDTO.SortDirection)] = "desc";
        } else {
            this[nameof(IndexDTO.SortDirection)] = "asc";
        }
    }

    private string Get(String key) => this[key] ?? null;

    public SortDictionary Clone() {
        SortDictionary clone = new SortDictionary();
        foreach (string key in Keys)
        {
            clone.Add(key, this[key]);
        }
        return clone;
    }
}