#region Includes
using System;
using System.Collections.Generic;
using System.Text;
#endregion

///////////////////////////////////////////////////////////////////////////////
// Copyright 2015 (c) by WX Test All Rights Reserved.
//  
// Project:      
// Module:       ICRegex.cs
// Description:  Interface for the C Regex class in the WX Test assembly.
//  
// Date:       Author:           Comments:
// 2015/11/5 14:28  dell     Module created.
///////////////////////////////////////////////////////////////////////////////
namespace WXTest
{

    /// <summary>
    /// Interface for the C Regex Class
    /// Documentation: 
    /// </summary>
    interface ICRegex
    {
        #region Property Definitions

        #region GeneratedProperties

        // No public properties were found. No tests are generated for non-public scoped properties.

        #endregion // End of GeneratedProperties

        #endregion

        #region Method Definitions

        #region GeneratedMethods

        /// <summary>
        /// Get Text Method
        /// Documentation   :  
        /// </summary>
        string GetText(string strData, string strRegex, string strKeyword);

        #endregion // End of GeneratedMethods

        #endregion

    }
}
