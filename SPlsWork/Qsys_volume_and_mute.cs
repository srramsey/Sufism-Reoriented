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

namespace UserModule_QSYS_VOLUME_AND_MUTE
{
    public class UserModuleClass_QSYS_VOLUME_AND_MUTE : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput CONNECTED;
        Crestron.Logos.SplusObjects.DigitalInput POLL;
        Crestron.Logos.SplusObjects.DigitalInput INVALIDATE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MUTE_TOGGLE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MUTE_ON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MUTE_OFF;
        Crestron.Logos.SplusObjects.StringInput RX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> VOLUME;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> CONTROLID;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MUTE_FB;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> VOLUME_FB;
        UShortParameter CHANGEGROUP_ID;
        CrestronString [] MUTENAMES;
        CrestronString [] VOLUMENAMES;
        ushort NPARAMS = 0;
        private void SENDTOQSYS (  SplusExecutionContext __context__, CrestronString SMSGTOSEND ) 
            { 
            
            __context__.SourceCodeLine = 124;
            TX__DOLLAR__  .UpdateValue ( SMSGTOSEND  ) ; 
            __context__.SourceCodeLine = 125;
            Functions.ProcessLogic ( ) ; 
            
            }
            
        private void POLLCHANGEGROUP (  SplusExecutionContext __context__ ) 
            { 
            CrestronString STOSEND;
            STOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
            
            
            __context__.SourceCodeLine = 132;
            if ( Functions.TestForTrue  ( ( CONNECTED  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 134;
                STOSEND  .UpdateValue ( "cgp " + Functions.ItoA (  (int) ( CHANGEGROUP_ID  .Value ) ) + "\r\n"  ) ; 
                __context__.SourceCodeLine = 135;
                SENDTOQSYS (  __context__ , STOSEND) ; 
                } 
            
            
            }
            
        private void INITCHANGEGROUP (  SplusExecutionContext __context__ ) 
            { 
            CrestronString TOSEND__DOLLAR__;
            TOSEND__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 144;
            TOSEND__DOLLAR__  .UpdateValue ( "cgc " + Functions.ItoA (  (int) ( CHANGEGROUP_ID  .Value ) ) + "\r\n"  ) ; 
            __context__.SourceCodeLine = 145;
            SENDTOQSYS (  __context__ , TOSEND__DOLLAR__) ; 
            __context__.SourceCodeLine = 146;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)NPARAMS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 148;
                TOSEND__DOLLAR__  .UpdateValue ( "cga " + Functions.ItoA (  (int) ( CHANGEGROUP_ID  .Value ) ) + " " + MUTENAMES [ I ] + "\r\n"  ) ; 
                __context__.SourceCodeLine = 149;
                SENDTOQSYS (  __context__ , TOSEND__DOLLAR__) ; 
                __context__.SourceCodeLine = 150;
                TOSEND__DOLLAR__  .UpdateValue ( "cga " + Functions.ItoA (  (int) ( CHANGEGROUP_ID  .Value ) ) + " " + VOLUMENAMES [ I ] + "\r\n"  ) ; 
                __context__.SourceCodeLine = 151;
                SENDTOQSYS (  __context__ , TOSEND__DOLLAR__) ; 
                __context__.SourceCodeLine = 146;
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
            
            
            __context__.SourceCodeLine = 165;
            TORETURN__DOLLAR__  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 166;
            DIVIDEND = (uint) ( ANALOGINPUT ) ; 
            __context__.SourceCodeLine = 167;
            DIVISOR = (uint) ( 65535 ) ; 
            __context__.SourceCodeLine = 169;
            uint __FN_FORSTART_VAL__1 = (uint) ( 1 ) ;
            uint __FN_FOREND_VAL__1 = (uint)4; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (uint)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 171;
                QUOTIENT = (uint) ( (DIVIDEND / DIVISOR) ) ; 
                __context__.SourceCodeLine = 172;
                REMAINDER = (uint) ( Mod( DIVIDEND , DIVISOR ) ) ; 
                __context__.SourceCodeLine = 173;
                TORETURN__DOLLAR__  .UpdateValue ( TORETURN__DOLLAR__ + Functions.LtoA (  (int) ( QUOTIENT ) )  ) ; 
                __context__.SourceCodeLine = 175;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (X == 1))  ) ) 
                    {
                    __context__.SourceCodeLine = 176;
                    TORETURN__DOLLAR__  .UpdateValue ( TORETURN__DOLLAR__ + "."  ) ; 
                    }
                
                __context__.SourceCodeLine = 179;
                DIVIDEND = (uint) ( (REMAINDER * 10) ) ; 
                __context__.SourceCodeLine = 169;
                } 
            
            __context__.SourceCodeLine = 182;
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
            
            
            __context__.SourceCodeLine = 194;
            MAXANALOG = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 196;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (POSITIONSTRING__DOLLAR__ == "1\r\n") ) || Functions.TestForTrue ( Functions.BoolToInt (POSITIONSTRING__DOLLAR__ == "1 ") )) ))  ) ) 
                {
                __context__.SourceCodeLine = 197;
                TORETURN = (ushort) ( MAXANALOG ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 198;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (POSITIONSTRING__DOLLAR__ == "0\r\n") ) || Functions.TestForTrue ( Functions.BoolToInt (POSITIONSTRING__DOLLAR__ == "0 ") )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 199;
                    TORETURN = (ushort) ( 0 ) ; 
                    }
                
                else 
                    { 
                    __context__.SourceCodeLine = 203;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( POSITIONSTRING__DOLLAR__ ) < 3 ))  ) ) 
                        {
                        __context__.SourceCodeLine = 204;
                        return (ushort)( 0) ; 
                        }
                    
                    __context__.SourceCodeLine = 205;
                    JUNK__DOLLAR__  .UpdateValue ( Functions.Remove ( 2, POSITIONSTRING__DOLLAR__ )  ) ; 
                    __context__.SourceCodeLine = 206;
                    NDIGITS = (ushort) ( (Functions.Length( POSITIONSTRING__DOLLAR__ ) - 2) ) ; 
                    __context__.SourceCodeLine = 207;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NDIGITS > 4 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 209;
                        POSITIONSTRING__DOLLAR__  .UpdateValue ( Functions.Left ( POSITIONSTRING__DOLLAR__ ,  (int) ( 4 ) )  ) ; 
                        __context__.SourceCodeLine = 210;
                        NDIGITS = (ushort) ( 4 ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 212;
                    VAL = (ushort) ( Functions.Atoi( POSITIONSTRING__DOLLAR__ ) ) ; 
                    __context__.SourceCodeLine = 213;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_1__ = ((int)NDIGITS);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 217;
                                TORETURN = (ushort) ( ((VAL * 6553) + (VAL / 2)) ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 221;
                                TORETURN = (ushort) ( ((VAL * 655) + ((VAL * 7) / 20)) ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 225;
                                TORETURN = (ushort) ( (((VAL * 65) + (VAL / 2)) + ((VAL * 7) / 200)) ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 229;
                                TORETURN = (ushort) ( ((((VAL * 6) + (VAL / 2)) + (VAL / 20)) + ((VAL * 7) / 2000)) ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 233;
                                TORETURN = (ushort) ( 0 ) ; 
                                } 
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                }
            
            __context__.SourceCodeLine = 237;
            return (ushort)( TORETURN) ; 
            
            }
            
        private void PARSEMUTE (  SplusExecutionContext __context__, CrestronString INCOMING__DOLLAR__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 244;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Find( "cv" , INCOMING__DOLLAR__ ) ))  ) ) 
                {
                __context__.SourceCodeLine = 245;
                return ; 
                }
            
            __context__.SourceCodeLine = 246;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)NPARAMS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 248;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Find( MUTENAMES[ I ] , INCOMING__DOLLAR__ ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 249;
                    continue ; 
                    }
                
                __context__.SourceCodeLine = 251;
                if ( Functions.TestForTrue  ( ( Functions.Find( "unmuted" , INCOMING__DOLLAR__ ))  ) ) 
                    {
                    __context__.SourceCodeLine = 252;
                    MUTE_FB [ I]  .Value = (ushort) ( 0 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 254;
                    MUTE_FB [ I]  .Value = (ushort) ( 1 ) ; 
                    }
                
                __context__.SourceCodeLine = 255;
                break ; 
                __context__.SourceCodeLine = 246;
                } 
            
            
            }
            
        private void PARSEVOLUME (  SplusExecutionContext __context__, CrestronString INCOMING__DOLLAR__ ) 
            { 
            ushort I = 0;
            
            ushort POS = 0;
            
            
            __context__.SourceCodeLine = 264;
            if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Find( "cv" , INCOMING__DOLLAR__ ) ))  ) ) 
                {
                __context__.SourceCodeLine = 265;
                return ; 
                }
            
            __context__.SourceCodeLine = 266;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)NPARAMS; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 268;
                if ( Functions.TestForTrue  ( ( Functions.Not( Functions.Find( VOLUMENAMES[ I ] , INCOMING__DOLLAR__ ) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 269;
                    continue ; 
                    }
                
                __context__.SourceCodeLine = 271;
                POS = (ushort) ( Functions.ReverseFindNoCase( " " , INCOMING__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 272;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (POS == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 273;
                    break ; 
                    }
                
                __context__.SourceCodeLine = 274;
                POS = (ushort) ( (Functions.Length( INCOMING__DOLLAR__ ) - POS) ) ; 
                __context__.SourceCodeLine = 275;
                INCOMING__DOLLAR__  .UpdateValue ( Functions.Right ( INCOMING__DOLLAR__ ,  (int) ( POS ) )  ) ; 
                __context__.SourceCodeLine = 276;
                VOLUME_FB [ I]  .Value = (ushort) ( PTOI( __context__ , INCOMING__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 277;
                break ; 
                __context__.SourceCodeLine = 266;
                } 
            
            
            }
            
        private void DOMUTE (  SplusExecutionContext __context__, ushort WHICH , ushort VAL ) 
            { 
            CrestronString STOSEND;
            STOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
            
            
            __context__.SourceCodeLine = 286;
            MakeString ( STOSEND , "csv {0} {1:d}\r\n", MUTENAMES [ WHICH ] , (short)VAL) ; 
            __context__.SourceCodeLine = 287;
            SENDTOQSYS (  __context__ , STOSEND) ; 
            __context__.SourceCodeLine = 288;
            CancelAllWait ( ) ; 
            __context__.SourceCodeLine = 289;
            CreateWait ( "DELAYEDPOLLMUTE" , 10 , DELAYEDPOLLMUTE_Callback ) ;
            
            }
            
        public void DELAYEDPOLLMUTE_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            {
            __context__.SourceCodeLine = 289;
            POLLCHANGEGROUP (  __context__  ) ; 
            }
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    object MUTE_TOGGLE_OnPush_0 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort LASTMODIFIEDINDEX = 0;
            
            ushort VAL = 0;
            
            
            __context__.SourceCodeLine = 302;
            LASTMODIFIEDINDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 304;
            VAL = (ushort) ( Functions.Not( MUTE_FB[ LASTMODIFIEDINDEX ] .Value ) ) ; 
            __context__.SourceCodeLine = 305;
            DOMUTE (  __context__ , (ushort)( LASTMODIFIEDINDEX ), (ushort)( VAL )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object MUTE_ON_OnPush_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort LASTMODIFIEDINDEX = 0;
        
        
        __context__.SourceCodeLine = 312;
        LASTMODIFIEDINDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 314;
        DOMUTE (  __context__ , (ushort)( LASTMODIFIEDINDEX ), (ushort)( 1 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MUTE_OFF_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort LASTMODIFIEDINDEX = 0;
        
        
        __context__.SourceCodeLine = 321;
        LASTMODIFIEDINDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 323;
        DOMUTE (  __context__ , (ushort)( LASTMODIFIEDINDEX ), (ushort)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort LASTMODIFIEDINDEX = 0;
        
        CrestronString STOSEND;
        STOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
        
        CrestronString CCOMMAND;
        CCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
        
        
        __context__.SourceCodeLine = 332;
        LASTMODIFIEDINDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 334;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VOLUME[ LASTMODIFIEDINDEX ] .UshortValue == VOLUME_FB[ LASTMODIFIEDINDEX ] .Value))  ) ) 
            { 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 341;
            STOSEND  .UpdateValue ( "csp " + VOLUMENAMES [ LASTMODIFIEDINDEX ] + " " + ITOP (  __context__ , (ushort)( VOLUME[ LASTMODIFIEDINDEX ] .UshortValue )) + "\r\n"  ) ; 
            __context__.SourceCodeLine = 342;
            SENDTOQSYS (  __context__ , STOSEND) ; 
            } 
        
        __context__.SourceCodeLine = 344;
        CancelAllWait ( ) ; 
        __context__.SourceCodeLine = 345;
        CreateWait ( "DELAYEDPOLLVOLUME" , 10 , DELAYEDPOLLVOLUME_Callback ) ;
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void DELAYEDPOLLVOLUME_CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            {
            __context__.SourceCodeLine = 345;
            POLLCHANGEGROUP (  __context__  ) ; 
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object RX__DOLLAR___OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString INCOMING__DOLLAR__;
        INCOMING__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
        
        
        __context__.SourceCodeLine = 352;
        INCOMING__DOLLAR__  .UpdateValue ( RX__DOLLAR__  ) ; 
        __context__.SourceCodeLine = 353;
        PARSEMUTE (  __context__ , INCOMING__DOLLAR__) ; 
        __context__.SourceCodeLine = 354;
        PARSEVOLUME (  __context__ , INCOMING__DOLLAR__) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CONNECTED_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 359;
        INITCHANGEGROUP (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object POLL_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 364;
        POLLCHANGEGROUP (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INVALIDATE_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString STOSEND;
        STOSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
        
        
        __context__.SourceCodeLine = 371;
        if ( Functions.TestForTrue  ( ( CONNECTED  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 373;
            STOSEND  .UpdateValue ( "cgi " + Functions.ItoA (  (int) ( CHANGEGROUP_ID  .Value ) ) + "\r\n"  ) ; 
            __context__.SourceCodeLine = 374;
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
        
        __context__.SourceCodeLine = 389;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 392;
        NPARAMS = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 393;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)30; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 395;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( CONTROLID[ I ] ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 397;
                MUTENAMES [ I ]  .UpdateValue ( CONTROLID [ I ] + "MUTE"  ) ; 
                __context__.SourceCodeLine = 398;
                VOLUMENAMES [ I ]  .UpdateValue ( CONTROLID [ I ] + "VOL"  ) ; 
                __context__.SourceCodeLine = 399;
                NPARAMS = (ushort) ( (NPARAMS + 1) ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 402;
                break ; 
                }
            
            __context__.SourceCodeLine = 393;
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
    MUTENAMES  = new CrestronString[ 31 ];
    for( uint i = 0; i < 31; i++ )
        MUTENAMES [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    VOLUMENAMES  = new CrestronString[ 31 ];
    for( uint i = 0; i < 31; i++ )
        VOLUMENAMES [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    
    CONNECTED = new Crestron.Logos.SplusObjects.DigitalInput( CONNECTED__DigitalInput__, this );
    m_DigitalInputList.Add( CONNECTED__DigitalInput__, CONNECTED );
    
    POLL = new Crestron.Logos.SplusObjects.DigitalInput( POLL__DigitalInput__, this );
    m_DigitalInputList.Add( POLL__DigitalInput__, POLL );
    
    INVALIDATE = new Crestron.Logos.SplusObjects.DigitalInput( INVALIDATE__DigitalInput__, this );
    m_DigitalInputList.Add( INVALIDATE__DigitalInput__, INVALIDATE );
    
    MUTE_TOGGLE = new InOutArray<DigitalInput>( 30, this );
    for( uint i = 0; i < 30; i++ )
    {
        MUTE_TOGGLE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MUTE_TOGGLE__DigitalInput__ + i, MUTE_TOGGLE__DigitalInput__, this );
        m_DigitalInputList.Add( MUTE_TOGGLE__DigitalInput__ + i, MUTE_TOGGLE[i+1] );
    }
    
    MUTE_ON = new InOutArray<DigitalInput>( 30, this );
    for( uint i = 0; i < 30; i++ )
    {
        MUTE_ON[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MUTE_ON__DigitalInput__ + i, MUTE_ON__DigitalInput__, this );
        m_DigitalInputList.Add( MUTE_ON__DigitalInput__ + i, MUTE_ON[i+1] );
    }
    
    MUTE_OFF = new InOutArray<DigitalInput>( 30, this );
    for( uint i = 0; i < 30; i++ )
    {
        MUTE_OFF[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MUTE_OFF__DigitalInput__ + i, MUTE_OFF__DigitalInput__, this );
        m_DigitalInputList.Add( MUTE_OFF__DigitalInput__ + i, MUTE_OFF[i+1] );
    }
    
    MUTE_FB = new InOutArray<DigitalOutput>( 30, this );
    for( uint i = 0; i < 30; i++ )
    {
        MUTE_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MUTE_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MUTE_FB__DigitalOutput__ + i, MUTE_FB[i+1] );
    }
    
    VOLUME = new InOutArray<AnalogInput>( 30, this );
    for( uint i = 0; i < 30; i++ )
    {
        VOLUME[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( VOLUME__AnalogSerialInput__ + i, VOLUME__AnalogSerialInput__, this );
        m_AnalogInputList.Add( VOLUME__AnalogSerialInput__ + i, VOLUME[i+1] );
    }
    
    VOLUME_FB = new InOutArray<AnalogOutput>( 30, this );
    for( uint i = 0; i < 30; i++ )
    {
        VOLUME_FB[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( VOLUME_FB__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( VOLUME_FB__AnalogSerialOutput__ + i, VOLUME_FB[i+1] );
    }
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( RX__DOLLAR____AnalogSerialInput__, 512, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    CONTROLID = new InOutArray<StringInput>( 30, this );
    for( uint i = 0; i < 30; i++ )
    {
        CONTROLID[i+1] = new Crestron.Logos.SplusObjects.StringInput( CONTROLID__AnalogSerialInput__ + i, CONTROLID__AnalogSerialInput__, 20, this );
        m_StringInputList.Add( CONTROLID__AnalogSerialInput__ + i, CONTROLID[i+1] );
    }
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    CHANGEGROUP_ID = new UShortParameter( CHANGEGROUP_ID__Parameter__, this );
    m_ParameterList.Add( CHANGEGROUP_ID__Parameter__, CHANGEGROUP_ID );
    
    DELAYEDPOLLMUTE_Callback = new WaitFunction( DELAYEDPOLLMUTE_CallbackFn );
    DELAYEDPOLLVOLUME_Callback = new WaitFunction( DELAYEDPOLLVOLUME_CallbackFn );
    
    for( uint i = 0; i < 30; i++ )
        MUTE_TOGGLE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MUTE_TOGGLE_OnPush_0, false ) );
        
    for( uint i = 0; i < 30; i++ )
        MUTE_ON[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MUTE_ON_OnPush_1, false ) );
        
    for( uint i = 0; i < 30; i++ )
        MUTE_OFF[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MUTE_OFF_OnPush_2, false ) );
        
    for( uint i = 0; i < 30; i++ )
        VOLUME[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( VOLUME_OnChange_3, false ) );
        
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_4, true ) );
    CONNECTED.OnDigitalPush.Add( new InputChangeHandlerWrapper( CONNECTED_OnPush_5, false ) );
    POLL.OnDigitalPush.Add( new InputChangeHandlerWrapper( POLL_OnPush_6, false ) );
    INVALIDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INVALIDATE_OnPush_7, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_QSYS_VOLUME_AND_MUTE ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction DELAYEDPOLLMUTE_Callback;
private WaitFunction DELAYEDPOLLVOLUME_Callback;


const uint CONNECTED__DigitalInput__ = 0;
const uint POLL__DigitalInput__ = 1;
const uint INVALIDATE__DigitalInput__ = 2;
const uint MUTE_TOGGLE__DigitalInput__ = 3;
const uint MUTE_ON__DigitalInput__ = 33;
const uint MUTE_OFF__DigitalInput__ = 63;
const uint RX__DOLLAR____AnalogSerialInput__ = 0;
const uint VOLUME__AnalogSerialInput__ = 1;
const uint CONTROLID__AnalogSerialInput__ = 31;
const uint MUTE_FB__DigitalOutput__ = 0;
const uint TX__DOLLAR____AnalogSerialOutput__ = 0;
const uint VOLUME_FB__AnalogSerialOutput__ = 1;
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
