namespace Phoneword
{
    public interface IDialer
    {
        // Built in method in Xamarin to allow the call function on the phone
        bool Dial(string number);
    }
}