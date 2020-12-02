import * as React from 'react'
import {ObjectResult} from './Search';

const Suggestions=({ results, onclickPassData}:{results:ObjectResult[],onclickPassData:(selected:ObjectResult)=>void})=>
{
    if(results.length!==0)
    {
        return(
            <div>
                <ul>
                    {results.map((r:ObjectResult)=>{
                        return(
                            <li key={r.id}><a onClick={()=>onclickPassData(r)} > {r.text}</a></li>)
                    })}
                </ul>
            </div>)
    }
    else
    {
        return(<></>)
    }
}

export default Suggestions
