# UnityAntiCheat
Simple Unity Anti Cheat to Protect your Values

## Add Api
Create a Folder in the Assets folder named Plugins and add the Dll in the Plugins folder

## Call InitValues() in Awake()
```csharp
   int count = 0;
   
  private void InitValues()
    {
        CountProtected = new ProtectedValue(count);
        count = CountProtected.GetInt();
    }
 ```
 
 ## UpdateValue and Check is Value Modified
```csharp
      private void AddValue()
    {
        if (CountProtected.CompareValue(count))
        {
            count = CountProtected.GetInt();
            count += 1;
            CountProtected.ApplyNewValue(count);
        }
        else
        {
            count = CountProtected.GetInt();
            Debug.LogError("CHEAT DETECTED!");
        }
    }
 ```
 ## That's it, simple or?
 important is that you don't set the scripting backend to mono but to IL2CPP when you build the game otherwise someone can easily read and change your assembly with dnspy.
To do this go to Edit > Project Settings > Player in your unity project and under other settings you will find it. 
