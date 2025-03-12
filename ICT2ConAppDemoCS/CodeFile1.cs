using ICT2ConAppDemoCS;

DelegateDemo DD = new DelegateDemo();

//testDelegate testDelegate1 = new testDelegate(DelegateDemo.GetStaticData);
//testDelegate testDelegate2 = new testDelegate(DD.GetInstanceData);
//testDelegate1();
//testDelegate2();

//dataManager dataManager = new dataManager(DD.GetUpdatedData);
//Console.WriteLine(dataManager(10));


Console.WriteLine(DD.UpdateData(6));
Console.WriteLine("===========================");


string ChangeValue(int b)
{
    return "Change of value result is " + (b * 5 + 3);
}

DD.UpdateData = new dataManager(ChangeValue);

Console.WriteLine(DD.UpdateData(7));

Console.WriteLine("===========================");

Test test = new Test();
DD.dataValue = 27;
DD.DataAfterUpdate(new dataUpdater(test.DataManipulator));


//=====================================================================


GetDataValues getDataValues =
    new GetDataValues(MulticastDelegateDemoCS.DataValue1);

Console.WriteLine(getDataValues());

GetDataValues getDataValues2 =
    new GetDataValues(MulticastDelegateDemoCS.DataValue2);

Console.WriteLine(getDataValues2());

Console.WriteLine("======================================");

GetDataValues getDataValues3 = getDataValues2 + getDataValues;

Console.WriteLine(getDataValues3());

Console.WriteLine("======================================");

getDataValues3 -= getDataValues;

Console.WriteLine(getDataValues3());

