
namespace ShoppingApp.BaseCode
{
    public interface IPageBase
    {
        string ParamsError { get; set; }
        bool CheckParams();
        void ShowParamsError();
    }
}