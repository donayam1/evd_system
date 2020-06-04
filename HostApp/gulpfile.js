/// <binding AfterBuild='CleanAndCopy' />
//<binding BeforeBuild='clean' AfterBuild='copy-extensions' Clean='clean' />
var gulp = require("gulp");
var del = require("del");
//command line arguments using yargs 
var argv = require('yargs').argv;

var paths = {
    Extensions: ['scripts/**/*.js', 'scripts/**/*.ts', 'scripts/**/*.map']
};



var version = "Debug";//Release 
if (argv.ver !== undefined) {
    version = argv.ver;
}
var dotNetCoreVersion = "netcoreapp3.0";
if (argv.netcore !== undefined) {
    dotNetCoreVersion = argv.netcore;
}
var sourceRoot = "C:/Users/Donayam/source/repos/";
var cryptographyRoot = sourceRoot + "EncryptionTest/";

var accountsRoot = sourceRoot + "SMSGateway/";
var tokensRoot = sourceRoot + "SMSGateway/Tokens/";
//var keyMangerRoot = "F:/Prj/EthioArt/ExtCore/src/";

var ethioartcoreroot = sourceRoot + "EthioArtCore/";
var syncBase = sourceRoot + "ParallelTest/";
var messagingRoot = sourceRoot + "Messaging/";
var appAccountRoot = sourceRoot + "ApplicationAccountManager/";
var keyManagerBase = sourceRoot + "KeyManager/";
var userAccountsBase = sourceRoot + "UserAccounts/UserAccounts/";
var backgroundJobsRoot = sourceRoot + "BackgroundJobs/";
var mobileSMSRoot = sourceRoot + "MobileSMSGateway/";
var remoteServicesBase = sourceRoot + "RemoteServices/";
var emailRoot = sourceRoot + "EmailClient/";

var smsClientBase = sourceRoot + "SMSSenderClient/";
var tokenValidatorBase = sourceRoot + "TokenValidation/";

var IdentityServerRoot = sourceRoot + "IdentityServer4.AspNetIdentity/";
var rolesRoot = IdentityServerRoot + "Role/";
var databaseInitRoot = sourceRoot + "DatabaseInitializer/";

var qrRoot = sourceRoot + "QrGenerator/";

var chageListenerRoot = sourceRoot + "ChangeListeners/";

var TakCoreRoot = "../Core/";
var TakAccountingRoot = "../Accounting/";
var TakUserRoot = "../Users/";
var TakVouchersRoot = "../Vouchers/";
var TakOperatorsRoot = "../Operators/";
var TakPoRoot = "../PurchaseOrders/";
gulp.task(
    "copy-extensions", function (cb) {
        gulp.src(["./OtherDeps/**"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakCoreRoot + "TaKTec.Core.Security/bin/" + version + "/" + dotNetCoreVersion + "/TaKTec.Core.Security.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakCoreRoot + "TaKTec.Core.APIs/bin/" + version + "/" + dotNetCoreVersion + "/TaKTec.Core.APIs.dll"]).pipe(gulp.dest("Extensions"));

        gulp.src([TakAccountingRoot + "TakTec.BusinessTransactions.Processors.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.BusinessTransactions.Processors.Abstraction.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakAccountingRoot + "TakTec.BusinessTransactions.MoneyDeposit.Processors/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.BusinessTransactions.MoneyDeposit.Processors.dll"]).pipe(gulp.dest("Extensions"));        

        gulp.src([TakUserRoot + "TakTec.Users.InitialDataSeed/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.Users.InitialDataSeed.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakUserRoot + "TakTec.Users.BusinessLogic/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.Users.BusinessLogic.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakUserRoot + "TakTec.Users.ServiceRegistrations/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.Users.ServiceRegistrations.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakUserRoot + "TakTec.Users.Constants/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.Users.Constants.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakUserRoot + "TakTec.Users.ViewModels/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.Users.ViewModels.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakUserRoot + "TakTec.Users.BusinessLogic.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.Users.BusinessLogic.Abstractions.dll"]).pipe(gulp.dest("Extensions"));
        

        gulp.src([TakOperatorsRoot + "TakTec.Operators.Backend/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.Operators.Backend.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakOperatorsRoot + "TakTec.Operators.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.Operators.Abstractions.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakOperatorsRoot + "TakTec.Operators.BusinessLogic/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.Operators.BusinessLogic.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakOperatorsRoot + "TakTec.Operators.BusinessLogic.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.Operators.BusinessLogic.Abstraction.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakOperatorsRoot + "TakTec.Operators.Entities/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.Operators.Entities.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakOperatorsRoot + "TakTec.Operators.EntityFramework/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.Operators.EntityFramework.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakOperatorsRoot + "TakTec.Operators.Mapper/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.Operators.Mapper.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakOperatorsRoot + "TakTec.Operators.ViewModel/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.Operators.ViewModel.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakOperatorsRoot + "TakTec.Operators.ServiceRegistrations/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.Operators.ServiceRegistrations.dll"]).pipe(gulp.dest("Extensions"));
        

        gulp.src([TakVouchersRoot + "Vouchers.Backend/bin/" + version + "/" + dotNetCoreVersion + "/Vouchers.Backend.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakVouchersRoot + "Vouchers.BusinessLogic/bin/" + version + "/" + dotNetCoreVersion + "/Vouchers.BusinessLogic.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakVouchersRoot + "Vouchers.BusinessLogic.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/Vouchers.BusinessLogic.Abstractions.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakVouchersRoot + "Vouchers.Data.Entities/bin/" + version + "/" + dotNetCoreVersion + "/Vouchers.Data.Entities.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakVouchersRoot + "Vouchers.Data.EntityFramework/bin/" + version + "/" + dotNetCoreVersion + "/Vouchers.Data.EntityFramework.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakVouchersRoot + "Vouchers.Data.Enumerations/bin/" + version + "/" + dotNetCoreVersion + "/Vouchers.Data.Enumerations.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakVouchersRoot + "Vouchers.ServiceRegistrations/bin/" + version + "/" + dotNetCoreVersion + "/Vouchers.ServiceRegistrations.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakVouchersRoot + "Vouchers.ViewModels/bin/" + version + "/" + dotNetCoreVersion + "/Vouchers.ViewModels.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakVouchersRoot + "Vouchers.Configurations/bin/" + version + "/" + dotNetCoreVersion + "/Vouchers.Configurations.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakVouchersRoot + "Vouchers.Data.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/Vouchers.Data.Abstractions.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakVouchersRoot + "Vouchers.ObjectMapper/bin/" + version + "/" + dotNetCoreVersion + "/Vouchers.ObjectMapper.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakVouchersRoot + "Vouchers.SignalHub.EndPoints/bin/" + version + "/" + dotNetCoreVersion + "/Vouchers.SignalHub.EndPoints.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakVouchersRoot + "Vouchers.Shared.ViewModels/bin/" + version + "/" + dotNetCoreVersion + "/Vouchers.Shared.ViewModels.dll"]).pipe(gulp.dest("Extensions"));
        


        gulp.src([TakPoRoot + "TakTec.PurchaseOrders.Entities/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.PurchaseOrders.Entities.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakPoRoot + "TakTec.PurchaseOrders.Backend/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.PurchaseOrders.Backend.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakPoRoot + "TakTec.PurchaseOrders.BusinessLogic/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.PurchaseOrders.BusinessLogic.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakPoRoot + "TakTec.PurchaseOrders.BusinessLogic.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.PurchaseOrders.BusinessLogic.Abstractions.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakPoRoot + "TakTec.PurchaseOrders.Data.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.PurchaseOrders.Data.Abstractions.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakPoRoot + "TakTec.PurchaseOrders.Entities/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.PurchaseOrders.Entities.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakPoRoot + "TakTec.PurchaseOrders.EntityFramework/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.PurchaseOrders.EntityFramework.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakPoRoot + "TakTec.PurchaseOrders.ViewModels/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.PurchaseOrders.ViewModels.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakPoRoot + "TakTec.PurchaseOrders.Enumerations/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.PurchaseOrders.Enumerations.dll"]).pipe(gulp.dest("Extensions"));
        gulp.src([TakPoRoot + "TakTec.PurchaseOrders.ServiceRegistrations/bin/" + version + "/" + dotNetCoreVersion + "/TakTec.PurchaseOrders.ServiceRegistrations.dll"]).pipe(gulp.dest("Extensions"));
        
        
        

        
        cb();
    }
);

gulp.task(
    "getDependencies", function (cb) {
        

        //gulp.src([bc]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([bc2]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([qrRoot + "EthioArt.PasswordGenerator/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.PasswordGenerator.dll"]).pipe(gulp.dest("OtherDeps"));

        gulp.src([ethioartcoreroot + "EthioArt.APIs/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.APIs.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "EthioArt.Data.Entities.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Data.Entities.Abstraction.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "EthioArt.Data.Entities/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Data.Entities.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "EthioArt.Data.EntityFramework/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Data.EntityFramework.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "EthioArt.Data.EntityFramework.MySql/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Data.EntityFramework.MySql.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([ethioartcoreroot + "EthioArt.Data.EntityFramework.SqlServer/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Data.EntityFramework.SqlServer.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "EthioArt.Data.Enumerations/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Data.Enumerations.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([keyMangerRoot+"EthioArt/EthioArt.Data.Extension/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Data.Extension.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "EthioArt.Data.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Data.Abstraction.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "EthioArt.Frontend/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Frontend.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([keyMangerRoot+"EthioArt/EthioArt.Frontend/bin/" + version + "/" + dotNetCoreVersion + "/am/EthioArt.Frontend.resources.dll"]).pipe(gulp.dest("OtherDeps/am"));
        gulp.src([ethioartcoreroot + "EthioArt.Security/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Security.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "EthioArt.Security.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Security.Abstraction.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "EthioArt.BusinessLogic.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.BusinessLogic.Abstraction.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([keyMangerRoot+"EthioArt/EthioArt.BusinessLogic/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.BusinessLogic.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "EthioArt.Filters.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Filters.Abstraction.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([keyMangerRoot+"EthioArt/EthioArt.Filters/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Filters.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "EthioArt.Extensions/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Extensions.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([keyMangerRoot+"EthioArt/EthioArt.Events.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Events.Abstraction.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "EthioArt.ServiceProviderAccessor/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.ServiceProviderAccessor.dll"]).pipe(gulp.dest("OtherDeps"));

        gulp.src([ethioartcoreroot + "EthioArt.Sorters/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Sorters.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "EthioArt.Sorters.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Sorters.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "EthioArt.PasswordGenerator/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.PasswordGenerator.dll"]).pipe(gulp.dest("OtherDeps"));


        gulp.src([ethioartcoreroot + "PhoneManager/EthioArt.PhoneManager.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.PhoneManager.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "PhoneManager/EthioArt.PhoneManager.Enumerations/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.PhoneManager.Enumerations.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "PhoneManager/EthioArt.PhoneManager.ServiceRegistration/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.PhoneManager.ServiceRegistration.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "PhoneManager/EthioArt.PhoneManager.Services/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.PhoneManager.Services.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "EthioArt.Configurations/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Configurations.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([ethioartcoreroot + "EthioArt.Backend.Models/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Backend.Models.dll"]).pipe(gulp.dest("OtherDeps"));



        //background jobs
        gulp.src([backgroundJobsRoot + "BackgroundJobs.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/BackgroundJobs.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([backgroundJobsRoot + "BackgroundJobs.Scheduler/bin/" + version + "/" + dotNetCoreVersion + "/BackgroundJobs.Scheduler.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([backgroundJobsRoot + "BackgroundJobs.ServiceRegistration/bin/" + version + "/" + dotNetCoreVersion + "/BackgroundJobs.ServiceRegistration.dll"]).pipe(gulp.dest("OtherDeps"));



        gulp.src([syncBase + "EthioArt.Syncronization/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Syncronization.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([syncBase + "EthioArt.Syncronization.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Syncronization.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([syncBase + "EthioArt.Syncronization.ServiceRegistration/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Syncronization.ServiceRegistration.dll"]).pipe(gulp.dest("OtherDeps"));

        gulp.src([mobileSMSRoot + "SMSNotifications/EthioArt.SMSGateway.SMSNotifications.Models/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.SMSGateway.SMSNotifications.Models.dll"]).pipe(gulp.dest("OtherDeps"));



        //EthioArt.AsymetricDataProtection.Abstraction
        //EthioArt.RSADataProtection
        //EthioArt.MsgPack.ObjectSerialization
        //gulp.src([cryptographyRoot + "EthioArt.MsgPack.ObjectSerialization/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.MsgPack.ObjectSerialization.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "EthioArt.DotNet.ObjectSerialization/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.DotNet.ObjectSerialization.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "EthioArt.ObjectSerialization.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.ObjectSerialization.Abstraction.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "EthioArt.AsymetricDataProtection.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.AsymetricDataProtection.Abstraction.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "EthioArt.RSADataProtection/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.RSADataProtection.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "EthioArt.Cryptography.BusinessLogic/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Cryptography.BusinessLogic.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "EthioArt.Cryptography.BusinessLogic.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Cryptography.BusinessLogic.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "EthioArt.Cryptography.Models/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Cryptography.Models.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "EthioArt.Cryptography.ServiceRegistration/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Cryptography.ServiceRegistration.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "EthioArt.ProtoBuffer.ObjectSerialization/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.ProtoBuffer.ObjectSerialization.dll"]).pipe(gulp.dest("OtherDeps"));

        //gulp.src([cryptographyRoot + "RSARequestProtector/EthioArt.Cryptography.RsaReqProtectors.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Cryptography.RsaReqProtectors.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "RSARequestProtector/EthioArt.Cryptography.RsaRequestProtectors/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Cryptography.RsaRequestProtectors.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "RSARequestProtector/EthioArt.Cryptography.RSAProtectors.ObjSerializers/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Cryptography.RSAProtectors.ObjSerializers.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "RSARequestProtector/EthioArt.Cryptography.RsaRequestProtectors.Models/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Cryptography.RsaRequestProtectors.Models.dll"]).pipe(gulp.dest("OtherDeps"));


        //gulp.src([cryptographyRoot + "HybrideProtector/EthioArt.Cryptography.HybrideProtector/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Cryptography.HybrideProtector.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "HybrideProtector/EthioArt.Cryptography.HybrideProtector.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Cryptography.HybrideProtector.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "HybrideProtector/EthioArt.Cryptography.HybrideProtector.Models/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Cryptography.HybrideProtector.Models.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "HybrideProtector/EthioArt.Cryptography.HybrideProtector.Extensions/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Cryptography.HybrideProtector.Extensions.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "HybrideProtector/EthioArt.Cryptography.HybrideProtector.ObjectSerialization/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Cryptography.HybrideProtector.ObjectSerialization.dll"]).pipe(gulp.dest("OtherDeps"));


        //gulp.src([cryptographyRoot + "AESProtectors/EthioArt.Cryptography.AESDataProtectors.Models/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Cryptography.AESDataProtectors.Models.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "AESProtectors/EthioArt.Cryptography.AESDataProtetctors/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Cryptography.AESDataProtetctors.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "AESProtectors/EthioArt.Cryptography.AESDataProtetctors.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Cryptography.AESDataProtetctors.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "AESProtectors/EthioArt.Cryptography.AesRequestProtectors.Extensions/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Cryptography.AesRequestProtectors.Extensions.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([cryptographyRoot + "AESProtectors/EthioArt.CryptogarphyAesDataProtectors.ObjectMappers/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.CryptogarphyAesDataProtectors.ObjectMappers.dll"]).pipe(gulp.dest("OtherDeps"));


        gulp.src([emailRoot + "Hulubeje.EmailClient.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/Hulubeje.EmailClient.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([emailRoot + "Hulubeje.EmailClient.Models/bin/" + version + "/" + dotNetCoreVersion + "/Hulubeje.EmailClient.Models.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([emailRoot + "Hulubeje.EmailClient.ServiceRegistration/bin/" + version + "/" + dotNetCoreVersion + "/Hulubeje.EmailClient.ServiceRegistration.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([emailRoot + "Hulubeje.EmailClient.Services/bin/" + version + "/" + dotNetCoreVersion + "/Hulubeje.EmailClient.Services.dll"]).pipe(gulp.dest("OtherDeps"));


        //Messaging 
        gulp.src([messagingRoot + "Messaging/Messages.BusinessLogic/bin/" + version + "/" + dotNetCoreVersion + "/Messages.BusinessLogic.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([messagingRoot + "Messaging/Messages.BusinessLogic.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/Messages.BusinessLogic.Abstraction.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([messagingRoot + "Messaging/Messages.Enumeration/bin/" + version + "/" + dotNetCoreVersion + "/Messages.Enumeration.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([messagingRoot + "Messaging/Messages.Models/bin/" + version + "/" + dotNetCoreVersion + "/Messages.Models.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([messagingRoot + "Messaging/Messages.ServiceRegistration/bin/" + version + "/" + dotNetCoreVersion + "/Messages.ServiceRegistration.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([messagingRoot + "Messaging/Messages.Logging.Extensions/bin/" + version + "/" + dotNetCoreVersion + "/Messages.Logging.Extensions.dll"]).pipe(gulp.dest("OtherDeps"));

        gulp.src([messagingRoot + "ScopedServiceProvider/EthioArt.ScopedServiceAcessor/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.ScopedServiceAcessor.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([messagingRoot + "ScopedServiceProvider/EthioArt.ScopedServiceAcessor.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.ScopedServiceAcessor.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([messagingRoot + "ScopedServiceProvider/EthioArt.ScopedServiceAcessor.ServiceRegistration/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.ScopedServiceAcessor.ServiceRegistration.dll"]).pipe(gulp.dest("OtherDeps"));




        gulp.src([keyManagerBase + "KeyManager.Data.Enumeration/bin/Debug/netstandard2.0/KeyManager.Data.Enumeration.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([keyManagerBase + "KeyManager.BusinessLogic/bin/" + version + "/" + dotNetCoreVersion + "/KeyManager.BusinessLogic.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([keyManagerBase + "KeyManager.BusinessLogic.DBKeyService/bin/" + version + "/" + dotNetCoreVersion + "/KeyManager.BusinessLogic.DBKeyService.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([keyManagerBase + "KeyManager.BusinessLogic.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/KeyManager.BusinessLogic.Abstraction.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([keyManagerBase + "KeyManager.Data.Entities/bin/" + version + "/" + dotNetCoreVersion + "/KeyManager.Data.Entities.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([keyManagerBase + "KeyManager.Data.EntityFramework/bin/" + version + "/" + dotNetCoreVersion + "/KeyManager.Data.EntityFramework.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([keyManagerBase + "KeyManager.Models/bin/" + version + "/" + dotNetCoreVersion + "/KeyManager.Models.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([keyManagerBase + "KeyManager.ObjectMapper/bin/" + version + "/" + dotNetCoreVersion + "/KeyManager.ObjectMapper.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([keyManagerBase + "KeyManager.Data.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/KeyManager.Data.Abstraction.dll"]).pipe(gulp.dest("OtherDeps"));


        //User Accounts
        gulp.src([userAccountsBase + "Users.BusinessLogic/bin/" + version + "/" + dotNetCoreVersion + "/Users.BusinessLogic.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([userAccountsBase + "Users.BusinessLogic.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/Users.BusinessLogic.Abstraction.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([userAccountsBase + "Users.Data.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/Users.Data.Abstraction.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([rolesRoot + "Roles.ViewModels/bin/" + version + "/" + dotNetCoreVersion + "/Roles.ViewModels.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([userAccountsBase + "Users.Data.Entities/bin/" + version + "/" + dotNetCoreVersion + "/Users.Data.Entities.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([userAccountsBase + "Users.Models/bin/" + version + "/" + dotNetCoreVersion + "/Users.Models.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([userAccountsBase + "Users.Data.EntityFramework/bin/" + version + "/" + dotNetCoreVersion + "/Users.Data.EntityFramework.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([userAccountsBase + "Users.ServiceRegistrations/bin/" + version + "/" + dotNetCoreVersion + "/Users.ServiceRegistrations.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([userAccountsBase + "EthioArt.Claims.Extensions/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Claims.Extensions.dll"]).pipe(gulp.dest("OtherDeps"));


        gulp.src([IdentityServerRoot + "EthioArt/IdentityServer.Configurations/bin/" + version + "/" + dotNetCoreVersion + "/IdentityServer.Configurations.dll"]).pipe(gulp.dest("OtherDeps"));

        gulp.src([IdentityServerRoot + "KeyManager/KeyManager.Backend/bin/" + version + "/" + dotNetCoreVersion + "/KeyManager.Backend.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "KeyManager/KeyManager.ServiceRegistration/bin/" + version + "/" + dotNetCoreVersion + "/KeyManager.ServiceRegistration.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "KeyManager/KeyManager.Data.InitialDataSeed/bin/" + version + "/" + dotNetCoreVersion + "/KeyManager.Data.InitialDataSeed.dll"]).pipe(gulp.dest("OtherDeps"));

        gulp.src([IdentityServerRoot + "Role/Roles.Backend/bin/" + version + "/" + dotNetCoreVersion + "/Roles.Backend.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Role/Roles.Mapper/bin/" + version + "/" + dotNetCoreVersion + "/Roles.Mapper.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Role/Roles.ViewModels/bin/" + version + "/" + dotNetCoreVersion + "/Roles.ViewModels.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Role/Roles.Security/bin/" + version + "/" + dotNetCoreVersion + "/Roles.Security.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Role/Roles.BusinessLogic/bin/" + version + "/" + dotNetCoreVersion + "/Roles.BusinessLogic.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Role/Roles.BusinessLogic.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/Roles.BusinessLogic.Abstraction.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Role/Roles.Claims/bin/" + version + "/" + dotNetCoreVersion + "/Roles.Claims.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Role/Roles.ServiceRegistration/bin/" + version + "/" + dotNetCoreVersion + "/Roles.ServiceRegistration.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Role/Roles.Enumerations/bin/" + version + "/" + dotNetCoreVersion + "/Roles.Enumerations.dll"]).pipe(gulp.dest("OtherDeps"));




        gulp.src([IdentityServerRoot + "AspNetIdentity/AspNetIdentity.Data.Entities/bin/" + version + "/" + dotNetCoreVersion + "/AspNetIdentity.Data.Entities.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "AspNetIdentity/AspNetIdentity.Data.EntityFramework/bin/" + version + "/" + dotNetCoreVersion + "/AspNetIdentity.Data.EntityFramework.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([IdentityServerRoot + "AspNetIdentity/AspNetIdentity.Data.InitialDataSeed/bin/" + version + "/" + dotNetCoreVersion + "/AspNetIdentity.Data.InitialDataSeed.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "AspNetIdentity/AspNetIdentity.Data.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/AspNetIdentity.Data.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "AspNetIdentity/AspNetIdentity.Data.ObjectMappers/bin/" + version + "/" + dotNetCoreVersion + "/AspNetIdentity.Data.ObjectMappers.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([IdentityServerRoot + "AspNetIdentity/AspNetIdentity.BankAccountSetUp.Jobs/bin/" + version + "/" + dotNetCoreVersion + "/AspNetIdentity.BankAccountSetUp.Jobs.dll"]).pipe(gulp.dest("OtherDeps"));

        gulp.src([accountsRoot + "Account/AccountsFactory/Accounts.Factories.Models/bin/" + version + "/" + dotNetCoreVersion + "/Accounts.Factories.Models.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([accountsRoot + "Account/Accounts.Enumeration/bin/" + version + "/" + dotNetCoreVersion + "/Accounts.Enumeration.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([appAccountRoot + "BankAccountSetUp.Remote.Services.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/BankAccountSetUp.Remote.Services.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([appAccountRoot + "BankAccountSetUp.Remote.Services/bin/" + version + "/" + dotNetCoreVersion + "/BankAccountSetUp.Remote.Services.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([appAccountRoot + "AccountManager.Models/bin/" + version + "/" + dotNetCoreVersion + "/AccountManager.Models.dll"]).pipe(gulp.dest("OtherDeps"));





        gulp.src([IdentityServerRoot + "IdentityServer4/IdentityServer4.AspNetIdentity/bin/" + version + "/" + dotNetCoreVersion + "/IdentityServer4.AspNetIdentity.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "IdentityServer4/IdentityServer4.Configuration/bin/" + version + "/" + dotNetCoreVersion + "/IdentityServer4.Configuration.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "IdentityServer4/IdentityServer4.Data.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/IdentityServer4.Data.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "IdentityServer4/IdentityServer4.Data.Entities/bin/" + version + "/" + dotNetCoreVersion + "/IdentityServer4.Data.Entities.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "IdentityServer4/IdentityServer4.Data.EntityFramework/bin/" + version + "/" + dotNetCoreVersion + "/IdentityServer4.Data.EntityFramework.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([IdentityServerRoot + "IdentityServer4/IdentityServer4.Data.InitDataSeed/bin/" + version + "/" + dotNetCoreVersion + "/IdentityServer4.Data.InitDataSeed.dll"]).pipe(gulp.dest("OtherDeps"));
        //gulp.src([IdentityServerRoot + "IdentityServer4.EntityFramework.StorageContext.SqlServer/bin/" + version + "/" + dotNetCoreVersion + "/IdentityServer4.EntityFramework.StorageContext.SqlServer.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "IdentityServer4/IdentityServer4.EntityFramework.StorageContext/bin/" + version + "/" + dotNetCoreVersion + "/IdentityServer4.EntityFramework.StorageContext.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "IdentityServer4/IdentityServer4.EntityFramework.StorageContext.MySql/bin/" + version + "/" + dotNetCoreVersion + "/IdentityServer4.EntityFramework.StorageContext.MySql.dll"]).pipe(gulp.dest("OtherDeps"));


        gulp.src([IdentityServerRoot + "IdentityServer4/IdentityServer4.EntityFrameworkBuilderExtensions/bin/" + version + "/" + dotNetCoreVersion + "/IdentityServer4.EntityFrameworkBuilderExtensions.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "IdentityServer4/IdentityServer4.Extension/bin/" + version + "/" + dotNetCoreVersion + "/IdentityServer4.Extension.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "IdentityServer4/IdentityServer4.Mappers/bin/" + version + "/" + dotNetCoreVersion + "/IdentityServer4.Mappers.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "IdentityServer4/IdentityServer4.Services/bin/" + version + "/" + dotNetCoreVersion + "/IdentityServer4.Services.dll"]).pipe(gulp.dest("OtherDeps"));


        gulp.src([databaseInitRoot + "EthioArt.EntityFramework.DatabaseInit/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.EntityFramework.DatabaseInit.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([databaseInitRoot + "EthioArt.EntityFramework.DatabaseInit.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.EntityFramework.DatabaseInit.Abstraction.dll"]).pipe(gulp.dest("OtherDeps"));

        //gulp.src(["C:/Users/Donayam/Documents/ExtCore/src/ExtCore.Data.EntityFramework/bin/Debug/netstandard2.0/ExtCore.Data.EntityFramework.dll"]).pipe(gulp.dest("OtherDeps"));

        gulp.src([IdentityServerRoot + "Accounts/EthioArt.UserAccounts.Backend/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.UserAccounts.Backend.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Accounts/EthioArt.UserAccounts.Models/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.UserAccounts.Models.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Accounts/EthioArt.UserAccounts.Security/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.UserAccounts.Security.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Accounts/EthioArt.UserAccounts.ServiceRegistration/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.UserAccounts.ServiceRegistration.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Accounts/EthioArt.UserAccounts.Services/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.UserAccounts.Services.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Accounts/EthioArt.UserAccounts.Services.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.UserAccounts.Services.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Accounts/EthioArt.UserAccounts.Claims/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.UserAccounts.Claims.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Accounts/EthioArt.UserAccounts.Mappers/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.UserAccounts.Mappers.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Accounts/EthioArt.UserAccounts.Validation/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.UserAccounts.Validation.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Accounts/EthioArt.UserAccounts.Enumerations/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.UserAccounts.Enumerations.dll"]).pipe(gulp.dest("OtherDeps"));



        gulp.src([IdentityServerRoot + "Clients/EthioArt.Clients.Security/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Clients.Security.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Clients/EthioArt.Clients.Mappers/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Clients.Mappers.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Clients/EthioArt.Clients.Services/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Clients.Services.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Clients/EthioArt.Clients.Services.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Clients.Services.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Clients/EthioArt.Clients.ViewModels/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Clients.ViewModels.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Clients/EthioArt.Clients.ServiceRegistration/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Clients.ServiceRegistration.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "Clients/EthioArt.Clients.Claims/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Clients.Claims.dll"]).pipe(gulp.dest("OtherDeps"));


        gulp.src([IdentityServerRoot + "ChangeListeners/IdentityServer.ChangeListeners/bin/" + version + "/" + dotNetCoreVersion + "/IdentityServer.ChangeListeners.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "ChangeListeners/IdentityServer.ChangeListeners.Constants/bin/" + version + "/" + dotNetCoreVersion + "/IdentityServer.ChangeListeners.Constants.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([IdentityServerRoot + "ChangeListeners/IdentityServer.ChangeListeners.Models/bin/" + version + "/" + dotNetCoreVersion + "/IdentityServer.ChangeListeners.Models.dll"]).pipe(gulp.dest("OtherDeps"));

        gulp.src([chageListenerRoot + "EthioArt.ChangeListeners.BusinessLogic/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.ChangeListeners.BusinessLogic.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([chageListenerRoot + "EthioArt.ChangeListeners.BusinessLogic.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.ChangeListeners.BusinessLogic.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([chageListenerRoot + "EthioArt.ChangeListeners.Data.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.ChangeListeners.Data.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([chageListenerRoot + "EthioArt.ChangeListeners.Entities/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.ChangeListeners.Entities.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([chageListenerRoot + "EthioArt.ChangeListeners.EntityFramework/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.ChangeListeners.EntityFramework.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([chageListenerRoot + "EthioArt.ChangeListeners.Jobs/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.ChangeListeners.Jobs.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([chageListenerRoot + "EthioArt.ChangeListeners.ObjectMappers/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.ChangeListeners.ObjectMappers.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([chageListenerRoot + "EthioArt.ChangeListeners.ViewModels/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.ChangeListeners.ViewModels.dll"]).pipe(gulp.dest("OtherDeps"));


        gulp.src([remoteServicesBase + "RemoteServices.Services/bin/" + version + "/" + dotNetCoreVersion + "/RemoteServices.Services.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([remoteServicesBase + "RemoteServices.Services.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/RemoteServices.Services.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));


        gulp.src([smsClientBase + "EthioArt.SMSClient.Models/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.SMSClient.Models.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([smsClientBase + "EthioArt.SMSClient.ServiceRegistrations/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.SMSClient.ServiceRegistrations.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([smsClientBase + "EthioArt.SMSClient.Services/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.SMSClient.Services.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([smsClientBase + "EthioArt.SMSClient.Services.Abstractions/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.SMSClient.Services.Abstractions.dll"]).pipe(gulp.dest("OtherDeps"));


        gulp.src([tokenValidatorBase + "EthioArt.Tokens.Abstraction/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Tokens.Abstraction.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([tokenValidatorBase + "EthioArt.Tokens.ServiceRegistration/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Tokens.ServiceRegistration.dll"]).pipe(gulp.dest("OtherDeps"));
        gulp.src([tokenValidatorBase + "EthioArt.Tokens.Validator/bin/" + version + "/" + dotNetCoreVersion + "/EthioArt.Tokens.Validator.dll"]).pipe(gulp.dest("OtherDeps"));

        cb();
    }
);

gulp.task('clean', function () {
    return del(['Extensions/**/*.dll']);
});

gulp.task('CleanAndCopy', gulp.series('clean', 'copy-extensions'));



gulp.task('clean-otherDepts', function () {
    return del(['otherDeps/**/*.dll']);
});

gulp.task('RecopyDeps', gulp.series('clean-otherDepts', 'getDependencies'));

