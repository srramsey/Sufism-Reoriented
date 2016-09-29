using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_QSYS_SINGLE_CORE_MODULE
{
    public class UserModuleClass_QSYS_SINGLE_CORE_MODULE : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput CONNECTF;
        Crestron.Logos.SplusObjects.BufferInput FROMCLIENT;
        Crestron.Logos.SplusObjects.BufferInput FROMDEVICES;
        Crestron.Logos.SplusObjects.DigitalOutput CONNECT;
        Crestron.Logos.SplusObjects.DigitalOutput CONNECTFTODEVICES;
        Crestron.Logos.SplusObjects.StringOutput TOCLIENT;
        Crestron.Logos.SplusObjects.StringOutput TODEVICES;
        StringParameter SPUSERNAME;
        StringParameter SPPIN;
        ushort ILOGGEDIN = 0;
        ushort IPRIMARY = 0;
        ushort IACTIVE = 0;
        ushort ISEQUENCE = 0;
        CrestronString SDESIGNNAME;
        CrestronString SDESIGNID;
        private void SENDTOQSYS (  SplusExecutionContext __context__, CrestronString SMSGTOSEND ) 
            { 
            
            __context__.SourceCodeLine = 147;
            TOCLIENT  .UpdateValue ( SMSGTOSEND  ) ; 
            __context__.SourceCodeLine = 148;
            Functions.ProcessLogic ( ) ; 
            
            }
            
        object FROMCLIENT_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                CrestronString FORPARSING__DOLLAR__;
                FORPARSING__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
                
                CrestronString TOSEND__DOLLAR__;
                TOSEND__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
                
                CrestronString JUNK__DOLLAR__;
                JUNK__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
                
                
                __context__.SourceCodeLine = 163;
                try 
                    { 
                    __context__.SourceCodeLine = 165;
                    while ( Functions.TestForTrue  ( ( 1)  ) ) 
                        { 
                        __context__.SourceCodeLine = 169;
                        FORPARSING__DOLLAR__  .UpdateValue ( Functions.Gather ( "\r\n" , FROMCLIENT )  ) ; 
                        __context__.SourceCodeLine = 172;
                        if ( Functions.TestForTrue  ( ( Functions.Find( "login_failed" , FORPARSING__DOLLAR__ ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 174;
                            ILOGGEDIN = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 175;
                            CONNECTFTODEVICES  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 176;
                            CONNECT  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 177;
                            CreateWait ( "__SPLS_TMPVAR__WAITLABEL_1__" , 10 , __SPLS_TMPVAR__WAITLABEL_1___Callback ) ;
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 184;
                            if ( Functions.TestForTrue  ( ( Functions.Find( "login_success" , FORPARSING__DOLLAR__ ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 186;
                                ILOGGEDIN = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 187;
                                CONNECTFTODEVICES  .Value = (ushort) ( 1 ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 191;
                                if ( Functions.TestForTrue  ( ( Functions.Find( "login_required" , FORPARSING__DOLLAR__ ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 193;
                                    ILOGGEDIN = (ushort) ( 0 ) ; 
                                    __context__.SourceCodeLine = 194;
                                    CONNECTFTODEVICES  .Value = (ushort) ( 0 ) ; 
                                    __context__.SourceCodeLine = 196;
                                    TOSEND__DOLLAR__  .UpdateValue ( "login " + SPUSERNAME + " " + SPPIN + "\r\n"  ) ; 
                                    __context__.SourceCodeLine = 197;
                                    SENDTOQSYS (  __context__ , TOSEND__DOLLAR__) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 200;
                                    if ( Functions.TestForTrue  ( ( Functions.Find( "bad_id" , FORPARSING__DOLLAR__ ))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 202;
                                        ILOGGEDIN = (ushort) ( 1 ) ; 
                                        __context__.SourceCodeLine = 203;
                                        CONNECTFTODEVICES  .Value = (ushort) ( 1 ) ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 207;
                                        if ( Functions.TestForTrue  ( ( Functions.Find( "sr" , FORPARSING__DOLLAR__ ))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 209;
                                            JUNK__DOLLAR__  .UpdateValue ( Functions.Remove ( "\"" , FORPARSING__DOLLAR__ )  ) ; 
                                            __context__.SourceCodeLine = 210;
                                            SDESIGNNAME  .UpdateValue ( Functions.Remove ( "\" \"" , FORPARSING__DOLLAR__ )  ) ; 
                                            __context__.SourceCodeLine = 211;
                                            SDESIGNNAME  .UpdateValue ( Functions.Left ( SDESIGNNAME ,  (int) ( (Functions.Length( SDESIGNNAME ) - 3) ) )  ) ; 
                                            __context__.SourceCodeLine = 212;
                                            SDESIGNID  .UpdateValue ( Functions.Remove ( "\" " , FORPARSING__DOLLAR__ )  ) ; 
                                            __context__.SourceCodeLine = 213;
                                            SDESIGNID  .UpdateValue ( Functions.Left ( SDESIGNID ,  (int) ( (Functions.Length( SDESIGNID ) - 2) ) )  ) ; 
                                            __context__.SourceCodeLine = 214;
                                            IPRIMARY = (ushort) ( Functions.Atoi( Functions.Remove( " " , FORPARSING__DOLLAR__ ) ) ) ; 
                                            __context__.SourceCodeLine = 215;
                                            IACTIVE = (ushort) ( Functions.Atoi( Functions.Remove( " " , FORPARSING__DOLLAR__ ) ) ) ; 
                                            } 
                                        
                                        else 
                                            { 
                                            __context__.SourceCodeLine = 221;
                                            TODEVICES  .UpdateValue ( FORPARSING__DOLLAR__  ) ; 
                                            __context__.SourceCodeLine = 222;
                                            Functions.ProcessLogic ( ) ; 
                                            } 
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        __context__.SourceCodeLine = 165;
                        } 
                    
                    } 
                
                catch (Exception __splus_exception__)
                    { 
                    SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                    
                    
                    }
                    
                    
                    
                }
                catch(Exception e) { ObjectCatchHandler(e); }
                finally { ObjectFinallyHandler( __SignalEventArg__ ); }
                return this;
                
            }
            
        public void __SPLS_TMPVAR__WAITLABEL_1___CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 179;
            CONNECT  .Value = (ushort) ( 1 ) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    object FROMDEVICES_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 233;
            try 
                { 
                __context__.SourceCodeLine = 235;
                while ( Functions.TestForTrue  ( ( 1)  ) ) 
                    { 
                    __context__.SourceCodeLine = 237;
                    TOCLIENT  .UpdateValue ( Functions.Gather ( "\r\n" , FROMDEVICES )  ) ; 
                    __context__.SourceCodeLine = 235;
                    } 
                
                } 
            
            catch (Exception __splus_exception__)
                { 
                SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                
                
                }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object CONNECTF_OnPush_2 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            CrestronString TOSEND__DOLLAR__;
            TOSEND__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 64, this );
            
            
            __context__.SourceCodeLine = 248;
            TOSEND__DOLLAR__  .UpdateValue ( "cg testconnection\r\n"  ) ; 
            __context__.SourceCodeLine = 249;
            SENDTOQSYS (  __context__ , TOSEND__DOLLAR__) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object CONNECTF_OnRelease_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 254;
        ILOGGEDIN = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 255;
        CONNECTFTODEVICES  .Value = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 268;
        CONNECT  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 277;
        ISEQUENCE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 279;
        while ( Functions.TestForTrue  ( ( 1)  ) ) 
            { 
            __context__.SourceCodeLine = 281;
            ISEQUENCE = (ushort) ( (ISEQUENCE + 1) ) ; 
            __context__.SourceCodeLine = 283;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISEQUENCE == 10))  ) ) 
                { 
                __context__.SourceCodeLine = 285;
                SENDTOQSYS (  __context__ , "sg\r\n") ; 
                __context__.SourceCodeLine = 286;
                ISEQUENCE = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 289;
            Functions.Delay (  (int) ( 500 ) ) ; 
            __context__.SourceCodeLine = 279;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    SDESIGNNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 64, this );
    SDESIGNID  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 64, this );
    
    CONNECTF = new Crestron.Logos.SplusObjects.DigitalInput( CONNECTF__DigitalInput__, this );
    m_DigitalInputList.Add( CONNECTF__DigitalInput__, CONNECTF );
    
    CONNECT = new Crestron.Logos.SplusObjects.DigitalOutput( CONNECT__DigitalOutput__, this );
    m_DigitalOutputList.Add( CONNECT__DigitalOutput__, CONNECT );
    
    CONNECTFTODEVICES = new Crestron.Logos.SplusObjects.DigitalOutput( CONNECTFTODEVICES__DigitalOutput__, this );
    m_DigitalOutputList.Add( CONNECTFTODEVICES__DigitalOutput__, CONNECTFTODEVICES );
    
    TOCLIENT = new Crestron.Logos.SplusObjects.StringOutput( TOCLIENT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TOCLIENT__AnalogSerialOutput__, TOCLIENT );
    
    TODEVICES = new Crestron.Logos.SplusObjects.StringOutput( TODEVICES__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TODEVICES__AnalogSerialOutput__, TODEVICES );
    
    FROMCLIENT = new Crestron.Logos.SplusObjects.BufferInput( FROMCLIENT__AnalogSerialInput__, 10000, this );
    m_StringInputList.Add( FROMCLIENT__AnalogSerialInput__, FROMCLIENT );
    
    FROMDEVICES = new Crestron.Logos.SplusObjects.BufferInput( FROMDEVICES__AnalogSerialInput__, 10000, this );
    m_StringInputList.Add( FROMDEVICES__AnalogSerialInput__, FROMDEVICES );
    
    SPUSERNAME = new StringParameter( SPUSERNAME__Parameter__, this );
    m_ParameterList.Add( SPUSERNAME__Parameter__, SPUSERNAME );
    
    SPPIN = new StringParameter( SPPIN__Parameter__, this );
    m_ParameterList.Add( SPPIN__Parameter__, SPPIN );
    
    __SPLS_TMPVAR__WAITLABEL_1___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_1___CallbackFn );
    
    FROMCLIENT.OnSerialChange.Add( new InputChangeHandlerWrapper( FROMCLIENT_OnChange_0, true ) );
    FROMDEVICES.OnSerialChange.Add( new InputChangeHandlerWrapper( FROMDEVICES_OnChange_1, true ) );
    CONNECTF.OnDigitalPush.Add( new InputChangeHandlerWrapper( CONNECTF_OnPush_2, false ) );
    CONNECTF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( CONNECTF_OnRelease_3, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_QSYS_SINGLE_CORE_MODULE ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_1___Callback;


const uint CONNECTF__DigitalInput__ = 0;
const uint FROMCLIENT__AnalogSerialInput__ = 0;
const uint FROMDEVICES__AnalogSerialInput__ = 1;
const uint CONNECT__DigitalOutput__ = 0;
const uint CONNECTFTODEVICES__DigitalOutput__ = 1;
const uint TOCLIENT__AnalogSerialOutput__ = 0;
const uint TODEVICES__AnalogSerialOutput__ = 1;
const uint SPUSERNAME__Parameter__ = 10;
const uint SPPIN__Parameter__ = 11;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
