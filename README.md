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

## Value Encryptor
as a little extra you can encrypt and decrypt strings for example if you want to store important game data that should not be immediately recognizable
```csharp
       ValueEncryptor EncryptorManager = new ValueEncryptor("HASH"); // Create The ValueEncryptor with a Hash example: !7xbaZW92a@
       string EnrcyptText = EncryptorManager.EncryptString("mySafeString"); // Encrypt the value "mySafeString";    
       string DecryptText = EncryptorManager.DecryptSrtings(EnrcyptText); // And Decrypt the Encrypt Value 
 ```
  ## That's it, simple or?
 important is that you don't set the scripting backend to mono but to IL2CPP when you build the game otherwise someone can easily read and change your assembly with [dnSpy](https://github.com/dnSpy/dnSpy). To do this go to Edit > Project Settings > Player in your unity project and under other settings you will find it. 

![myImage](https://media.giphy.com/media/XRB1uf2F9bGOA/giphy.gif)
