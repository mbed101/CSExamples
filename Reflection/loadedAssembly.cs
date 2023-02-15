using System.Reflection;

var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
string s = "";

foreach (var a in loadedAssemblies)
{
    var types = a.GetTypes();
    Console.WriteLine(types.Length);
    s += ("Assembly name:" + a.FullName + " \n " + "--------------------------" + "\n");
    foreach (Type tc in types)
    {
        if (tc.IsAbstract)
        {
            s+= ("Abstract Class : " + tc.Name + "\n");
        }
        else if (tc.IsPublic)
        {
            s += ("Public Class : " + tc.Name + "\n");
        }
        else if (tc.IsSealed)
        {
           s+= ("Sealed Class : " + tc.Name + "\n");
        }

        //Get List of Method Names of Class
        MemberInfo[] methodName = tc.GetMethods();
        foreach (MemberInfo method in methodName)
        {
            if (method.ReflectedType.IsPublic)
            {
                s += ("Public Method : " + method.Name.ToString() + "\n");
            }
            else
            {
                s+= ("Non-Public Method : " + method.Name.ToString() + "\n");
            }
        }
    }
}
System.IO.File.WriteAllText(@"C:\D\Ref.txt", s);
