import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FilemanagerComponent } from './filemanager.component';
import { FilemanagerRoutes } from './filemanager.routing';

@NgModule({
    imports: [
        CommonModule,
        RouterModule.forChild(FilemanagerRoutes),
        FormsModule
    ],
    declarations: [FilemanagerComponent]
})

export class FilemanagerModule {}
