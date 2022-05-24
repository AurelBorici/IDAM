using AutoMapper;
using MigrationMSSQL;
using Perstistence.Dapper;

namespace Perstistence.Handlers;

public abstract class BaseHandler
{
    protected readonly IDapperConnectionProvider _dapperConnectionProvider;
    protected readonly IDAMContext _idamContext;
    protected readonly IMapper _mapper;

    public BaseHandler(IDapperConnectionProvider dapperConnectionProvider, IDAMContext idamContext, IMapper mapper)
    {
        _dapperConnectionProvider = dapperConnectionProvider;
        _idamContext = idamContext;
        _mapper = mapper;
    }
}
