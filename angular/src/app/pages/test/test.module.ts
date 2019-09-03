import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { TestComponent } from './test.component';

export const routes = [
    { path: '', component: TestComponent, pathMatch: 'full' }
];

@NgModule({
    declarations: [TestComponent],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        SharedModule
    ]
})
export class TestModule { }
