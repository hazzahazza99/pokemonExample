import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PokemonGridComponent } from './pokemon-grid/pokemon-grid.component';
import { TrainerGridComponent } from './trainer-grid/trainer-grid.component';
import { DxButtonModule, DxDataGridModule, DxDrawerModule, DxFormModule } from 'devextreme-angular';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    PokemonGridComponent,
    TrainerGridComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    DxDataGridModule,
    DxDrawerModule,
    DxFormModule,
    DxButtonModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
