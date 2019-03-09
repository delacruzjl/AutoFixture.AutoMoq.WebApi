[![NuGet Badge](https://buildstats.info/nuget/AutoFixture.AutoMoq.WebApi)](https://www.nuget.org/packages/AutoFixture.AutoMoq.WebApi/) <span style="display: block; text-align: right;">[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)</span>

# AutoFixture.AutoMoq.WebApi

See [http://stackoverflow.com/questions/19908385/automocking-web-api-2-controller] for details.


## Usage

When creating your Fixture, make sure you add the customize conventions as:

### Note

You won't need to add the Moq customization, ApiControllerConventions already includes that customization.

```
  private readonly Fixture _fixture;
  
  public YourTestClassConstructor(){
    _fixture = new Fixture();
     _fixture.Customize(new ApiControllerConventions()); //Important!
  }
  ...
  
  //When instantiating your API controller system under test use
  _systemUnderTestAPIController = _fixture.Create<YourApiController>();
  
  
```
