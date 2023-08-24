using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ViewIndex
{
    EmptyView=0,
    HomeView,
    ChooseMissionView,
}
public enum ViewNeedPhoton
{
    HomeView = 1,
    WaittingView = 2
}
public class ViewConfig 
{
    public static ViewIndex[] viewIndices = {
     ViewIndex.EmptyView,
     ViewIndex.HomeView,
     ViewIndex.ChooseMissionView,
     };
}
public class ViewParam
{

}
public class HomeViewParam: ViewParam
{

}