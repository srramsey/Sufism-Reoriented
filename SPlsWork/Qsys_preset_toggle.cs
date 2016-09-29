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

namespace UserModule_QSYS_PRESET_TOGGLE
{
    public class UserModuleClass_QSYS_PRESET_TOGGLE : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput CONNECTED;
        Crestron.Logos.SplusObjects.DigitalInput POLL;
        Crestron.Logos.SplusObjects.DigitalInput INVALIDATE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> PRESET_TOGGLE;
        Crestron.Logos.SplusObjects.StringInput RX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> CONTROLID;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> PRESET_FB;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        UShortParameter CHANGEGROUP_ID;
        CrestronString [] PRESETNAMES;
        ushort NPARAMS = 0;
        private void SENDTOQSYS (  SplusExecutionContext __context__, CrestronString SMSGTOSEND ) 
            { 
            
            __context__.SourceCodeLine = 116;
            TX__DOLLAR__  .UpdateValue ( SMSGTOSEND  ) ; 
            __context__.SourceCodeLine = 117;
            Functions.ProcessLogic ( ) ; 
            
            }
            
        private void POLLCHANGEGROUP (  SplusExecutionContext __context__ ) 
            { 
            CrestronString STOSEND;
            STOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
            
            
            __context__.SourceCodeLine = 124;
            if ( Functions.TestForTrue  ( ( CONNECTED  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 126;
                STOSEND  .UpdateValue ( "cgp " + Functions.ItoA (  (int) ( CHANGEGROUP_ID  .Value ) ) + "\r\n"  ) ; 
                __context__.SourceCodeLine = 127;
                SENDTOQSYS (  __context__ , STOSEND) ; 
                } 
            
            
            }
            
        private void INITCHANGEGROUP (  SplusExecutionContext __context__ ) 
            { 
            CrestronString TOSEND__DOLLAR__;
            TOSEND__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 136;
            TOSEND__DOLLAR__  .UpdateValue ( "cgc " + Functions.ItoA (  (int) ( CHANGEGROUP_ID  .Value ) ) + "\r\n"  ) ; 
            __context__.SourceCodeLine = 137;
            SENDTOQSYS (  __context__ , TOSEND__DOLLAR__) ; 
            __context__.SourceCodeLine = 138;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)NPARAMS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 140;
                TOSEND__DOLLAR__  .UpdateValue ( "cga " + Functions.ItoA (  (int) ( CHANGEGROUP_ID  .Value ) ) + " " + PRESETNAMES [ I ] + "\r\n"  ) ; 
                __context__.SourceCodeLine = 141;
                SENDTOQSYS (  __context__ , TOSEND__DOLLAR__) ; 
                __context__.SourceCodeLine = 138;
                } 
            
            
            }
            
        private CrestronString ITOP (  SplusExecutionContext __context__, ushort ANALOGINPUT ) 
            { 
            CrestronString TORETURN__DOLLAR__;
            TORETURN__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
            
            uint DIVIDEND = 0;
            
            uint DIVISOR = 0;
            
            uint QUOTIENT = 0;
            
            uint REMAINDER = 0;
            
            uint X = 0;
            
            
            __context__.SourceCodeLine = 155;
            TORETURN__DOLLAR__  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 156;
            DIVIDEND = (uint) ( ANALOGINPUT ) ; 
            __context__.SourceCodeLine = 157;
            DIVISOR = (uint) ( 65535 ) ; 
            __context__.SourceCodeLine = 159;
            uint __FN_FORSTART_VAL__1 = (uint) ( 1 ) ;
            uint __FN_FOREND_VAL__1 = (uint)4; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (uint)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 161;
                QUOTIENT = (uint) ( (DIVIDEND / DIVISOR) ) ; 
                __context__.SourceCodeLine = 162;
                REMAINDER = (uint) ( Mod( DIVIDEND , DIVISOR ) ) ; 
                __context__.SourceCodeLine = 163;
                TORETURN__DOLLAR__  .UpdateValue ( TORETURN__DOLLAR__ + Functions.LtoA (  (int) ( QUOTIENT ) )  ) ; 
                __context__.SourceCodeLine = 165;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (X == 1))  ) ) 
                    {
                    __context__.SourceCodeLine = 166;
                    TORETURN__DOLLAR__  .UpdateValue ( TORETURN__DOLLAR__ + "."  ) ; 
                    }
                
                __context__.SourceCodeLine = 169;
                DIVIDEND = (uint) ( (REMAINDER * 10) ) ; 
                __context__.SourceCodeLine = 159;
                } 
            
            __context__.SourceCodeLine = 172;
            return ( TORETURN__DOLLAR__ ) ; 
            
            }
            
        private ushort PTOI (  SplusExecutionContext __context__, CrestronString POSITIONSTRING__DOLLAR__ ) 
            { 
            ushort TORETURN = 0;
            
            ushort MAXANALOG = 0;
            
            ushort VAL = 0;
            
            ushort NDIGITS = 0;
            
            CrestronString JUNK__DOLLAR__;
            JUNK__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
            
            CrestronString CURRENTDIGIT__DOLLAR__;
            CURRENTDIGIT__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
            
            
            __context__.SourceCodeLine = 184;
            MAXANALOG = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 186;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (POSITIONSTRING__DOLLAR__ == "1\r\n") ) || Functions.TestForTrue ( Functions.BoolToInt (POSITIONSTRING__DOLLAR__ == "1 ") )) ))  ) ) 
                {
                __context__.SourceCodeLine = 187;
                TORETURN = (ushort) ( MAXANALOG ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 188;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (POSITIONSTRING__DOLLAR__ == "0\r\n") ) || Functions.TestForTrue ( Functions.BoolToInt (POSITIONSTRING__DOLLAR__ == "0 ") )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 189;
                    TORETURN = (ushort) ( 0 ) ; 
                    }
                
                else 
                    { 
                    __context__.SourceCodeLine = 193;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( POSITIONSTRING__DOLLAR__ ) < 3 ))  ) ) 
                        {
                        __context__.SourceCodeLine = 194;
                        return (ushort)( 0) ; 
                        }
                    
                    __context__.SourceCodeLine = 195;
                    JUNK__DOLLAR__  .UpdateValue ( Functions.Remove ( 2, POSITIONSTRING__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 196;
                    NDIGITS = (ushort) ( (Functions.Length( POSITIONSTRING__DOLLAR__ ) - 2) ) ; 
                    __context__.SourceCodeLine = 197;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NDIGITS > 4 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 199;
                        POSITIONSTRING__DOLLAR__  .UpdateValue ( Functions.Left ( POSITIONSTRING__DOLLAR__ ,  (int) ( 4 ) )  ) ; 
                        __context__.SourceCodeLine = 200;
                        NDIGITS = (ushort) ( 4 ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 202;
                    VAL = (ushort) ( Functions.Atoi( POSITIONSTRING__DOLLAR__ ) ) ; 
                    __context__.SourceCodeLine = 203;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_1__ = ((int)NDIGITS);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 207;
                                TORETURN = (ushort) ( ((VAL * 6553) + (VAL / 2)) ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 211;
                                TORETURN = (ushort) ( ((VAL * 655) + ((VAL * 7) / 20)) ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 215;
                                TORETURN = (ushort) ( (((VAL * 65) + (VAL / 2)) + ((VAL * 7) / 200)) ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 219;
                                TORETURN = (ushort) ( ((((VAL * 6) + (VAL / 2)) + (VAL / 20)) + ((VAL * 7) / 2000)) ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 223;
                                TORETURN = (ushort) ( 0 ) ; 
                                } 
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                }
            
            __context__.SourceCodeLine = 227;
            return (ushort)( TORETURN) ; 
            
            }
            
        private void PARSEPRESET (  SplusExecutionContext __context__, CrestronString INCOMING__DOLLAR__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 234;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Find( "cv" , INCOMING__DOLLAR__ ) ))  ) ) 
                {
                __context__.SourceCodeLine = 235;
                return ; 
                }
            
            __context__.SourceCodeLine = 236;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)NPARAMS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 238;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Find( PRESETNAMES[ I ] , INCOMING__DOLLAR__ ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 239;
                    continue ; 
                    }
                
                __context__.SourceCodeLine = 241;
                if ( Functions.TestForTrue  ( ( Functions.Find( "true" , INCOMING__DOLLAR__ ))  ) ) 
                    {
                    __context__.SourceCodeLine = 242;
                    PRESET_FB [ I]  .Value = (ushort) ( 1 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 244;
                    PRESET_FB [ I]  .Value = (ushort) ( 0 ) ; 
                    }
                
                __context__.SourceCodeLine = 245;
                break ; 
                __context__.SourceCodeLine = 236;
                } 
            
            
            }
            
        private void DOPRESET (  SplusExecutionContext __context__, ushort WHICH , ushort VAL ) 
            { 
            CrestronString STOSEND;
            STOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
            
            
            __context__.SourceCodeLine = 254;
            MakeString ( STOSEND , "csv {0} {1:d}\r\n", PRESETNAMES [ WHICH ] , (short)VAL) ; 
            __context__.SourceCodeLine = 255;
            SENDTOQSYS (  __context__ , STOSEND) ; 
            __context__.SourceCodeLine = 256;
            CancelAllWait ( ) ; 
            __context__.SourceCodeLine = 257;
            CreateWait ( "DELAYEDPOLLPRESET" , 10 , DELAYEDPOLLPRESET_Callback ) ;
            
            }
            
        public void DELAYEDPOLLPRESET_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            {
            __context__.SourceCodeLine = 257;
            POLLCHANGEGROUP (  __context__  ) ; 
            }
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    object PRESET_TOGGLE_OnPush_0 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort LASTMODIFIEDINDEX = 0;
            
            
            __context__.SourceCodeLine = 269;
            LASTMODIFIEDINDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 271;
            DOPRESET (  __context__ , (ushort)( LASTMODIFIEDINDEX ), (ushort)( 1 )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object RX__DOLLAR___OnChange_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString INCOMING__DOLLAR__;
        INCOMING__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
        
        
        __context__.SourceCodeLine = 278;
        INCOMING__DOLLAR__  .UpdateValue ( RX__DOLLAR__  ) ; 
        __context__.SourceCodeLine = 279;
        PARSEPRESET (  __context__ , INCOMING__DOLLAR__) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CONNECTED_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 284;
        INITCHANGEGROUP (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object POLL_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 289;
        POLLCHANGEGROUP (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INVALIDATE_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString STOSEND;
        STOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
        
        
        __context__.SourceCodeLine = 296;
        if ( Functions.TestForTrue  ( ( CONNECTED  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 298;
            STOSEND  .UpdateValue ( "cgi " + Functions.ItoA (  (int) ( CHANGEGROUP_ID  .Value ) ) + "\r\n"  ) ; 
            __context__.SourceCodeLine = 299;
            SENDTOQSYS (  __context__ , STOSEND) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    ushort I = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 314;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 317;
        NPARAMS = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 318;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)16; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 320;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( CONTROLID[ I ] ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 322;
                PRESETNAMES [ I ]  .UpdateValue ( CONTROLID [ I ]  ) ; 
                __context__.SourceCodeLine = 323;
                NPARAMS = (ushort) ( (NPARAMS + 1) ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 326;
                break ; 
                }
            
            __context__.SourceCodeLine = 318;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    PRESETNAMES  = new CrestronString[ 17 ];
    for( uint i = 0; i < 17; i++ )
        PRESETNAMES [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    
    CONNECTED = new Crestron.Logos.SplusObjects.DigitalInput( CONNECTED__DigitalInput__, this );
    m_DigitalInputList.Add( CONNECTED__DigitalInput__, CONNECTED );
    
    POLL = new Crestron.Logos.SplusObjects.DigitalInput( POLL__DigitalInput__, this );
    m_DigitalInputList.Add( POLL__DigitalInput__, POLL );
    
    INVALIDATE = new Crestron.Logos.SplusObjects.DigitalInput( INVALIDATE__DigitalInput__, this );
    m_DigitalInputList.Add( INVALIDATE__DigitalInput__, INVALIDATE );
    
    PRESET_TOGGLE = new InOutArray<DigitalInput>( 16, this );
    for( uint i = 0; i < 16; i++ )
    {
        PRESET_TOGGLE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( PRESET_TOGGLE__DigitalInput__ + i, PRESET_TOGGLE__DigitalInput__, this );
        m_DigitalInputList.Add( PRESET_TOGGLE__DigitalInput__ + i, PRESET_TOGGLE[i+1] );
    }
    
    PRESET_FB = new InOutArray<DigitalOutput>( 16, this );
    for( uint i = 0; i < 16; i++ )
    {
        PRESET_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( PRESET_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( PRESET_FB__DigitalOutput__ + i, PRESET_FB[i+1] );
    }
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( RX__DOLLAR____AnalogSerialInput__, 512, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    CONTROLID = new InOutArray<StringInput>( 16, this );
    for( uint i = 0; i < 16; i++ )
    {
        CONTROLID[i+1] = new Crestron.Logos.SplusObjects.StringInput( CONTROLID__AnalogSerialInput__ + i, CONTROLID__AnalogSerialInput__, 20, this );
        m_StringInputList.Add( CONTROLID__AnalogSerialInput__ + i, CONTROLID[i+1] );
    }
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    CHANGEGROUP_ID = new UShortParameter( CHANGEGROUP_ID__Parameter__, this );
    m_ParameterList.Add( CHANGEGROUP_ID__Parameter__, CHANGEGROUP_ID );
    
    DELAYEDPOLLPRESET_Callback = new WaitFunction( DELAYEDPOLLPRESET_CallbackFn );
    
    for( uint i = 0; i < 16; i++ )
        PRESET_TOGGLE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( PRESET_TOGGLE_OnPush_0, false ) );
        
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_1, true ) );
    CONNECTED.OnDigitalPush.Add( new InputChangeHandlerWrapper( CONNECTED_OnPush_2, false ) );
    POLL.OnDigitalPush.Add( new InputChangeHandlerWrapper( POLL_OnPush_3, false ) );
    INVALIDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INVALIDATE_OnPush_4, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_QSYS_PRESET_TOGGLE ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction DELAYEDPOLLPRESET_Callback;


const uint CONNECTED__DigitalInput__ = 0;
const uint POLL__DigitalInput__ = 1;
const uint INVALIDATE__DigitalInput__ = 2;
const uint PRESET_TOGGLE__DigitalInput__ = 3;
const uint RX__DOLLAR____AnalogSerialInput__ = 0;
const uint CONTROLID__AnalogSerialInput__ = 1;
const uint PRESET_FB__DigitalOutput__ = 0;
const uint TX__DOLLAR____AnalogSerialOutput__ = 0;
const uint CHANGEGROUP_ID__Parameter__ = 10;

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
