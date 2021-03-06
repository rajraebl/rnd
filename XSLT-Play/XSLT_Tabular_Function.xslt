﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>


  <xsl:template match="Employees">
    <table width="50%">
      <tr align="left">
        <th>EmpId</th>
        <th>Name</th>
        <th>Sex</th>
        <th>Phone</th>
      </tr>
      <xsl:call-template name="results"></xsl:call-template>
    </table>

    </xsl:template>
  
  <xsl:template name="results">
      <xsl:for-each select="Employee">
        <tr>
          <td>
            <xsl:value-of select="EmpId"/>
          </td>
          <td>
            <xsl:value-of select="Name"/>
          </td>
          <td>
            <xsl:value-of select="Sex"/>
          </td>
          <td>
            <xsl:value-of select="Phone"/>
          </td>
        </tr>
        
      </xsl:for-each>

  </xsl:template>

  
</xsl:stylesheet>
