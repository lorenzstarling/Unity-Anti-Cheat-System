# UnityAntiCheat
Simple Unity Anti Cheat to Protect your Values

## Add Api
Create a Folder in the Assets folder named Plugins and add the Dll in the Plugins folder

## CallInitValues() in Awake()
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
