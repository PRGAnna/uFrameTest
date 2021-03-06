// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace test {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using test;
    using uFrame.ECS.APIs;
    using uFrame.ECS.Components;
    using uFrame.ECS.Systems;
    using uFrame.Kernel;
    using UniRx;
    using UnityEngine;
    
    
    public partial class TestSystemBase : uFrame.ECS.Systems.EcsSystem {
        
        private IEcsComponentManagerOf<TestComponentNode> _TestComponentNodeManager;
        
        private TestSystemOnMouseDownHandler TestSystemOnMouseDownHandlerInstance = new TestSystemOnMouseDownHandler();
        
        public IEcsComponentManagerOf<TestComponentNode> TestComponentNodeManager {
            get {
                return _TestComponentNodeManager;
            }
            set {
                _TestComponentNodeManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            TestComponentNodeManager = ComponentSystem.RegisterComponent<TestComponentNode>(1);
            this.OnEvent<uFrame.ECS.UnityUtilities.MouseDownDispatcher>().Subscribe(_=>{ TestSystemOnMouseDownFilter(_); }).DisposeWith(this);
        }
        
        protected virtual void TestSystemOnMouseDownHandler(uFrame.ECS.UnityUtilities.MouseDownDispatcher data, TestComponentNode source) {
            var handler = TestSystemOnMouseDownHandlerInstance;
            handler.System = this;
            handler.Event = data;
            handler.Source = source;
            StartCoroutine(handler.Execute());
        }
        
        protected void TestSystemOnMouseDownFilter(uFrame.ECS.UnityUtilities.MouseDownDispatcher data) {
            var SourceTestComponentNode = TestComponentNodeManager[data.EntityId];
            if (SourceTestComponentNode == null) {
                return;
            }
            if (!SourceTestComponentNode.Enabled) {
                return;
            }
            this.TestSystemOnMouseDownHandler(data, SourceTestComponentNode);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("2667ea79-0597-4e9c-8973-88b2b0298978")]
    public partial class TestSystem : TestSystemBase {
        
        private static TestSystem _Instance;
        
        public TestSystem() {
            Instance = this;
        }
        
        public static TestSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
