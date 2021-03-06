

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 8.01.0622 */
/* at Tue Jan 19 11:14:07 2038
 */
/* Compiler settings for BookCloudATL.idl:
    Oicf, W1, Zp8, env=Win32 (32b run), target_arch=X86 8.01.0622 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */



/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 500
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif /* __RPCNDR_H_VERSION__ */

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __BookCloudATL_i_h__
#define __BookCloudATL_i_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IATLTemp_FWD_DEFINED__
#define __IATLTemp_FWD_DEFINED__
typedef interface IATLTemp IATLTemp;

#endif 	/* __IATLTemp_FWD_DEFINED__ */


#ifndef __ATLTemp_FWD_DEFINED__
#define __ATLTemp_FWD_DEFINED__

#ifdef __cplusplus
typedef class ATLTemp ATLTemp;
#else
typedef struct ATLTemp ATLTemp;
#endif /* __cplusplus */

#endif 	/* __ATLTemp_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"
#include "shobjidl.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __IATLTemp_INTERFACE_DEFINED__
#define __IATLTemp_INTERFACE_DEFINED__

/* interface IATLTemp */
/* [unique][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IATLTemp;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("c8154e1a-bd4c-4e83-a026-3e7c3a9dc39e")
    IATLTemp : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Multiplier( 
            /* [in] */ DOUBLE __num1,
            /* [in] */ DOUBLE __num2,
            /* [retval][out] */ DOUBLE *__result) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IATLTempVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IATLTemp * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IATLTemp * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IATLTemp * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IATLTemp * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IATLTemp * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IATLTemp * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IATLTemp * This,
            /* [annotation][in] */ 
            _In_  DISPID dispIdMember,
            /* [annotation][in] */ 
            _In_  REFIID riid,
            /* [annotation][in] */ 
            _In_  LCID lcid,
            /* [annotation][in] */ 
            _In_  WORD wFlags,
            /* [annotation][out][in] */ 
            _In_  DISPPARAMS *pDispParams,
            /* [annotation][out] */ 
            _Out_opt_  VARIANT *pVarResult,
            /* [annotation][out] */ 
            _Out_opt_  EXCEPINFO *pExcepInfo,
            /* [annotation][out] */ 
            _Out_opt_  UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Multiplier )( 
            IATLTemp * This,
            /* [in] */ DOUBLE __num1,
            /* [in] */ DOUBLE __num2,
            /* [retval][out] */ DOUBLE *__result);
        
        END_INTERFACE
    } IATLTempVtbl;

    interface IATLTemp
    {
        CONST_VTBL struct IATLTempVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IATLTemp_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IATLTemp_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IATLTemp_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IATLTemp_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IATLTemp_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IATLTemp_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IATLTemp_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define IATLTemp_Multiplier(This,__num1,__num2,__result)	\
    ( (This)->lpVtbl -> Multiplier(This,__num1,__num2,__result) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IATLTemp_INTERFACE_DEFINED__ */



#ifndef __BookCloudATLLib_LIBRARY_DEFINED__
#define __BookCloudATLLib_LIBRARY_DEFINED__

/* library BookCloudATLLib */
/* [version][uuid] */ 


EXTERN_C const IID LIBID_BookCloudATLLib;

EXTERN_C const CLSID CLSID_ATLTemp;

#ifdef __cplusplus

class DECLSPEC_UUID("138e8479-d981-4ac9-a7da-a07970a42ead")
ATLTemp;
#endif
#endif /* __BookCloudATLLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


