// dllmain.h: 模块类的声明。

class CBookCloudATLModule : public ATL::CAtlDllModuleT< CBookCloudATLModule >
{
public :
	DECLARE_LIBID(LIBID_BookCloudATLLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_BOOKCLOUDATL, "{63adfab8-8333-4759-a418-ad0050729138}")
};

extern class CBookCloudATLModule _AtlModule;
