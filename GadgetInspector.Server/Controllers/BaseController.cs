namespace GadgetInspector.Server.Controllers;

[ApiController]
[Route(DefaultControllerRoute)]
public abstract class BaseController() : ControllerBase
{
    #region Constants
    //Use when you need an abnormal controller route for whatever reason.
    //Route would be something like: [Route(DefaultRoutePrefix + "someText/whateverMakesSense")].
    //Note that for individual action methods, you wouldn't need this.
    //If you had an action method with an id parameter, you could use something like:
    //[Route("{id}")]
    public const string DefaultRoutePrefix = "api/v1/";

    //Use for the default controller route.
    //Use when you want to match to action methods that match verb names, like GET/POST.
    //If your controller was "MyController", you can access the default route with
    //this URL:  "api/v1/My"
    //[Route(DefaultRoute)]
    public const string DefaultControllerRoute = DefaultRoutePrefix + "[controller]";

    //Use for individual action methods that are not named after verbs (GET, POST, PUT etc)
    public const string NamedAction = "[action]";
    #endregion

    #region Methods
    protected int GetUserId()
    {
        //TODO: This is just for fun.  User #1 is always the user logged in for this demo
        return 1;
    }
    #endregion
}
