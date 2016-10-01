# ErrorUnit.Injector_SimpleInjector
Compatibility library for ErrorUnit to work with SimpleInjector Dependency Injector.

At the start up of your application; You will need to set up the Injector with:

`ErrorUnitCentral._Injector = new ErrorUnitInjector();`
and
`ErrorUnitCentral._LinkInjector(container);`

http://johngoldinc.com/Help/html/T_ErrorUnit_Interfaces_IInjector.htm