import { NgModule } from '@angular/core';
import { TokenService } from './token.service';
import * as socialLogin from 'angularx-social-login';
import { AuthServiceConfig, GoogleLoginProvider } from 'angularx-social-login';
import { environment } from 'src/environments/environment';
import { PropertyService } from './property.service';
import {
    CityServiceProxy,
    CategoryServiceProxy,
    TagServiceProxy,
    ConfigurationServiceProxy,
    RoleServiceProxy,
    AccountServiceProxy,
    CountryServiceProxy,
    CurrencyServiceProxy,
    PropertyServiceProxy,
    TokenAuthServiceProxy,
    TenantServiceProxy,
    UserServiceProxy
} from './service.base';

let config = new AuthServiceConfig([
    {
        id: GoogleLoginProvider.PROVIDER_ID,
        provider: new GoogleLoginProvider(environment.googleAuthClientId)
    }/* ,
    {
      id: FacebookLoginProvider.PROVIDER_ID,
      provider: new FacebookLoginProvider("Facebook-App-Id")
    } */
]);

export function provideConfig() {
    return config;
}
@NgModule({
    providers: [
        CityServiceProxy,
        CategoryServiceProxy,
        TagServiceProxy,
        ConfigurationServiceProxy,
        RoleServiceProxy,
        AccountServiceProxy,
        CountryServiceProxy,
        CurrencyServiceProxy,
        PropertyServiceProxy,
        TokenAuthServiceProxy,
        UserServiceProxy,
        TenantServiceProxy,
        socialLogin.AuthService,
        PropertyService,
        TokenService,
        { provide: AuthServiceConfig, useFactory: provideConfig }
    ]
})
export class ServiceBaseModule { }