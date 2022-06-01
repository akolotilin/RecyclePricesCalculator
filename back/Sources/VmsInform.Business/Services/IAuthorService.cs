using VmsInform.DAL.Domain.Common;

namespace VmsInform.Business.Services
{
    public interface IAuthorService
    {
        void SetupCreator(IEditorInfo editorInfo);
        void SetupEditor(IEditorInfo editorInfo);
    }
}
