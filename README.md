# AR Foundation Samples
Example projects that use *AR Foundation 2.2* and demonstrate its functionality with sample assets and components.

This set of samples relies on four Unity packages:

* ARSubsystems
* ARCore XR Plugin
* ARKit XR Plugin
* ARFoundation

ARSubsystems defines an interface, and the platform-specific implementations are in the ARCore and ARKit packages. ARFoundation turns the AR data provided by ARSubsystems into Unity `GameObject`s and `MonoBehavour`s.

The `master` branch is compatible with Unity 2019.1 and later. For 2018.4, see the [1.5-preview branch](https://github.com/Unity-Technologies/arfoundation-samples/tree/1.5-preview). ARFoundation 1.5 is functionality equivalent to 2.2. The only difference is the version of Unity on which it depends.

## :warning: ARKit 3 Support

**TL;DR:** If you want to checkout the latest and greatest features in ARKit 3, use this `master` branch, Xcode 11 beta 5, and a device running iOS 13 beta. Otherwise, see the [2.1 branch](https://github.com/Unity-Technologies/arfoundation-samples/tree/2.1), which only lacks support for the new ARKit 3 features.

The `master` branch includes support for ARKit 3, which is still in beta and requires Xcode 11 beta 5 and iOS 13 beta 5.

The [2.1 branch](https://github.com/Unity-Technologies/arfoundation-samples/tree/2.1) is compatible with Xcode 9 and 10 and only lacks the new ARKit 3 features.

ARFoundation 2.2 provides interfaces for ARKit 3 features, but only Unity's ARKit XR Plugin 2.2 package contains _support_ for these features and _requires_ Xcode 11 beta 5 and iOS 13 beta 5. Unity's ARKit XR Plugin 2.2 is not backwards compatible with previous versions of Xcode or iOS. Unity's ARKit XR Plugin 2.1 will work with the latest ARFoundation (it just doesn't implement the ARKit 3 features).

While Xcode 11 & iOS 13 are in beta, we will continue to maintain *both* the 2.2 and 2.1 versions of the packages.

The same is also true for Unity's ARKit Face Tracking package 1.1: it _requires_ Xcode 11 beta 5 and iOS 13 beta 5.

This table shows the latest version of Unity's ARKit XR Plugin and its Xcode and iOS compatibility:

|Unity ARKit XR Plugin|Unity ARKit Face Tracking|Xcode Version|iOS Version|
|---------------------|-------------------------|-------------|-----------|
|2.2                  |1.1                      |11 beta 5    | 13 beta 5 |
|2.1                  |1.0                      |9 or 10      | 11 or 12  |

This distinciton is temporary. Once iOS 13 is no longer in beta, the ARKit package is expected to work with all versions of Xcode 9+ and iOS 11+.

## Instructions for installing AR Foundation

1. Download the latest version of Unity 2019.1 or later.

2. Open Unity, and load the project at the root of the *arfoundation-samples* repository.

3. Open your choice of sample scene.

4. See the [AR Foundation Documentation](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@latest?preview=1) for usage instructions and more information.

## References

### Tutorials

Getting Started with Unity: https://learn.unity.com/course/getting-started-with-unity

Getting Started with AR Foundation: https://www.youtube.com/watch?v=Ml2UakwRxjk

Video tutorial for using this repo: https://www.youtube.com/watch?v=7dvy7L9cDfE

### Articles

Unity’s Handheld AR Ecosystem: https://blogs.unity3d.com/2018/12/18/unitys-handheld-ar-ecosystem-ar-foundation-arcore-and-arkit

AR Foundation support for ARKit 3: https://blogs.unity3d.com/2019/06/06/ar-foundation-support-for-arkit-3/

### Repositories

AR Foundation samples: https://github.com/Unity-Technologies/arfoundation-samples

Graffiti App: https://github.com/arjundube/arfoundation-samples

### APIs

Unity Primitives: https://docs.unity3d.com/Manual/PrimitiveObjects.html

Unity Buttons: https://docs.unity3d.com/Manual/script-Button.html

Unity Tags and Layers: https://docs.unity3d.com/Manual/class-TagManager.html

Unity MeshRenderer: https://docs.unity3d.com/Manual/class-MeshRenderer.html

Unity TrailRenderer: https://docs.unity3d.com/Manual/class-TrailRenderer.html

AR Foundation: https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@2.2/manual/index.html

AR Subsystems: https://docs.unity3d.com/Packages/com.unity.xr.arsubsystems@2.1/manual/index.html

Android Developer Mode https://developer.android.com/studio/debug/dev-options
