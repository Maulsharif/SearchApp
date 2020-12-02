import * as React from 'react'
import {ObjectResult} from './Search';

const RenderSelected=({res}:{res?:ObjectResult})=>
{
    return(
        <div>
            <p>{res?.id} {res?.text}</p>
        </div>)
}
export default RenderSelected;