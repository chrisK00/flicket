# flicket
A fun learning project to take a covid safe trip and also learn the different reasons why simple razor pages are usually a better fit than MVC and how certain design choices can come back and haunt us in the future.

A good example is using simple data annotations instead of something like FluentValidation for the VMs. It pollutes the models and forces us to either make custom validators or install another package. A big issue with MVC is the View which is unlike WPF and Razor Pages coupled with its ViewModel, the issue is that you can only have one Model on the View (A ViewModel) or alternatively something like a tuple. The ViewModels become huge and polluted as a result of this. Directly binding to properties on your ViewModel is a much smarter move. Also having one controller for many operations is a smart move on a Web Api because they shouldnt contain any sort of logic (hence incoming Minimal Api's) but when you have a View that means you will need some more logic such as building a ViewModel to not give your View another responsibility. Binding View with ViewModel is what most frameworks use: Angular, Razor Pages, WPF, React in a way that they are one and not separated. 

The one positive benefit of an MVC controller is that it can act as a normal API and easily be converted but if you are doing a Razor Pages app you could just make a Api controller anyways and you would follow SRP better while keeping everything maintainable and not in one heavy bag.

Not meant to be a great example of good design but rather quick development while utilising the many available features of .Net, MVC and packages such as MediatR to provide a somewhat maintainable project