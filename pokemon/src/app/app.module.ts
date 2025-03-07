import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PokemonGridComponent } from './pokemon-grid/pokemon-grid.component';
import { TrainerGridComponent } from './trainer-grid/trainer-grid.component';
import { DxButtonModule, DxDataGridModule, DxDrawerModule, DxFormModule, DxTabsModule, DxTemplateModule, DxValidationGroupModule, DxValidatorModule } from 'devextreme-angular';
import { HttpClientModule } from '@angular/common/http';
import { TopbarComponent } from './topbar/topbar.component';
import { MovesGridComponent } from './moves-grid/moves-grid.component';
import { TypesListComponent } from './types-list/types-list.component';
import { RegionsGridComponent } from './regions-grid/regions-grid.component';
import { EvolutionsLinkComponent } from './evolutions-link/evolutions-link.component';
import { PictureGalleryComponent } from './picture-gallery/picture-gallery.component';

@NgModule({
  declarations: [
    AppComponent,
    PokemonGridComponent,
    TrainerGridComponent,
    TopbarComponent,
    MovesGridComponent,
    TypesListComponent,
    RegionsGridComponent,
    EvolutionsLinkComponent,
    PictureGalleryComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    DxDataGridModule,
    DxDrawerModule,
    DxFormModule,
    DxButtonModule,
    DxTemplateModule,
    DxValidatorModule,
    DxValidationGroupModule,
    DxTabsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
