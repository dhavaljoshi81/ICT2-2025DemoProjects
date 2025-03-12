using ICT2ConAppDemoCS;


CallbackMethodDemoCs callBackClass = new CallbackMethodDemoCs();

callBackClass.value1 = 10;
callBackClass.value2 = 20;

callBackClass.CallUpdateData = 
    new UpdateMyData(CallBackDemoFunctionsCollectionCS.UpdateValue);

callBackClass.CallUpdateData +=
    new UpdateMyData(CallBackDemoFunctionsCollectionCS.ShowValue);

callBackClass.GetResult();


