

namespace YggdrasilMarshaler.Models
{
	public class YggdrasilSafeModel
	{
        public int ErrCode { get; }
        public YggdrasilSafeHandle SafeHandle { get; init; }


        public YggdrasilSafeModel(YggdrasilUnsafeReturnStruct model)
		{
            ErrCode = model.errCode;
            SafeHandle = new YggdrasilSafeHandle(model.safeHandle, true);
        }
	}
}

