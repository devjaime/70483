# Metodos Anonimos

Sabiendo que:

- El metodo del observador solo sera utilizado por el observado.
- Et delegado ha definido explicitamente la firma del metodo.

Se puede reducir el numero de lineas de codigo con metodos sin nombre que van a definir el cuerpo del metodo al momento de suscribirse al evento.

Ejemplo:

```csharp
  // Este metodo anonimo se suscribe al evento click del boton MyButton
  MyButton.Click += delegate(object sender, eventargs e){Console.Write("Esto es un metodo anonimo !")};
```

> [Documentacion C# : "Metodos anonimos"](https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-methods)