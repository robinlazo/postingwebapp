namespace SocialMedia.Models;

public class IndexSession {
    private string SessionKey = "IndexCurrentSessionKey";
    private SortDictionary Routes { get; set; }
    private ISession Session { get; set; }

    public IndexSession(ISession sess) {
        Session = sess;
        Routes = Session.GetObject<SortDictionary>(SessionKey) ?? new SortDictionary();
    }

    public IndexSession(ISession sess, IndexDTO currentRoute) {
        Session = sess;
        Routes = new SortDictionary {
            SortDirection = currentRoute.SortDirection, 
            CategoryFilter = currentRoute.Category
        };
        
        SaveRouteSegments();
    }

    private void SaveRouteSegments() => Session.SetObject<SortDictionary>(SessionKey, Routes);

    public SortDictionary CurrentRoute => Routes;

    public bool HasCategory => Routes.CategoryFilter != "all";
}