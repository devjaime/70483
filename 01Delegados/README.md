# Delegados

-	Les délégués sont des objects definissant un prototype de methode (statique ou d’instance) avec ses paramettrees et le type de retour.
-	Ils peuvent contenir une collection de references compatibles avec le prototype (signature et valeur de retour)
-	Ils peuvent etre passés a une autre méthode en tant que paramètre et exécutée donc par la méthode qui a été appelée.


> Ejemplo de pregunta sobre los delegados : [Q1](https://ticapacitacion.com/foros/20001)

## DEFINIR UN DELEGADO

> [Explicacion:](https://www.youtube.com/watch?v=_-98c1gaTfI&t=20m8s)

```csharp
 public delegate void Divide(int A, int B)
```

> [Documentation C#](https://docs.microsoft.com/fr-fr/dotnet/csharp/delegates-events)