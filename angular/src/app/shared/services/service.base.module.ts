import { NgModule } from '@angular/core';
import * as Api from './service.base'

@NgModule({
    providers: [
        Api.CityService,
        Api.ConfigurationService,
        Api.RoleService,
        Api.AccountService,
        Api.CountryService,
        Api.CurrencyService,
        Api.PropertyService,
        Api.TokenAuthService,
        Api.TenantService
    ]
})
export class ServiceBaseModule { }